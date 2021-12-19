
using HealthyToothsModels;
using HealthyTeeth.Services;
using MaterialDesignExtensions.Controls;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HealthyTeeth.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : BaseWindow
    {
        #region Fields
        private string login;
        private string password;
        private bool isLoginEnabled;
        #endregion

        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;
            isLoginEnabled = true;
        }

        #region Properties
        public string Login { get => login; set { login = value; OnPropertyChanged(); } }
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        public bool IsLoginEnabled { get => isLoginEnabled; set { isLoginEnabled = value; OnPropertyChanged(); } }
        #endregion

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            IsLoginEnabled = false;
            Password = passwordText.Password;
            //Отпрвляем запрос на сервер для авторизации
            var response = await UserService.Instance.apiService.SendPostRequest("api/Authentication/loginEmployee", new { Login = Login, Password = Password });
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //Если успешно авторизировались, то, в зависимости от роли, открываем новое окно
                UserService.Instance.SetEmployee(JsonConvert.DeserializeObject<Employee>(response.Content));
                UserService.Instance.InitializeHubConnection();
                await UserService.Instance.HubConnection.StartAsync();
                switch (UserService.Instance.Employee.Role.RoleId)
                {
                    case 1:
                        {
                            var doctorWindow = new DoctorWindow() { WindowStartupLocation = WindowStartupLocation.CenterScreen };
                            doctorWindow.Show();
                            this.Close();
                        }
                        break;
                    case 3:
                        {
                            var administratorWindow = new AdministratorWindow() { WindowStartupLocation = WindowStartupLocation.CenterScreen };
                            administratorWindow.Show();
                            this.Close();
                        }
                        break;
                }
                CustomMessageBox.Show($"Добро пожаловать, {UserService.Instance.Employee.FullName}", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                //Если нерпавлиьный логин или пароль
                IsLoginEnabled = true;
                var errorMessage = "";
                var errors = JsonConvert.DeserializeObject<List<ModelStateException>>(response.Content);
                errors.ForEach(p => errorMessage += p.ErrorMessage + "\n");
                CustomMessageBox.Show(errorMessage, "Внимание, произошла ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //Если нет соединения с сервером
                IsLoginEnabled = true;
                var errorMessage = response.ErrorMessage;
                CustomMessageBox.Show(errorMessage, "Внимание, произошла ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
