using HealthyTeeth.Services;
using Newtonsoft.Json;
using System.Windows;
using HealthyTeeth.Models;

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
            var response = await APIService.Authorize(Login, Password);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //Если успешно авторизировались, то, в зависимости от роли, открываем новое окно
                var data = JsonConvert.DeserializeObject<TokenModel>(response.Content);
                UserService.Instance.SetClient(data.user_name, data.full_name, data.role_id, data.user_id, data.access_token);
                UserService.Instance.InitializeHubConnection();
                await UserService.Instance.HubConnection.StartAsync();
                switch (UserService.Instance.Employee.RoleId)
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
                var errors = response.Content.ToString();
                CustomMessageBox.Show(errors, "Внимание, произошла ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
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
