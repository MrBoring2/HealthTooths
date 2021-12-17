using HealthyTeeth.POCO_Classes;
using HealthyTeeth.Services;
using MaterialDesignExtensions.Controls;
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
        private string login;
        private string password;
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public string Login { get => login; set { login = value; OnPropertyChanged(); } }
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var request = new RestRequest("api/Authentication/loginEmployee", Method.POST).AddJsonBody(new { Login = Login, Password = Password });
            var response = await UserService.Instance.apiService.SendGetRequest(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                UserService.Instance.SetEmployee(JsonConvert.DeserializeObject<Employee>(response.Content));
                switch (UserService.Instance.Employee.Role.RoleId)
                {
                    case 1:
                        {
                            var doctorWindow = new DoctorWindow();
                            doctorWindow.Show();
                            this.Close();
                        }break;
                    case 2:
                        {
                            var accountantWindow = new AccountantWindow();
                            accountantWindow.Show();
                            this.Close();
                        }
                        break;
                    case 3:
                        {
                            var administratorWindow = new AdministratorWindow();
                            administratorWindow.Show();
                            this.Close();
                        }
                        break;
                }
                MessageBox.Show($"Добро пожаловать, {UserService.Instance.Employee.FullName}", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var errorMessage = "";
                var errors = JsonConvert.DeserializeObject<List<ModelStateException>>(response.Content);
                errors.ForEach(p => errorMessage += p.ErrorMessage + "\n");
                MessageBox.Show(errorMessage, "Внимание, произошла ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
