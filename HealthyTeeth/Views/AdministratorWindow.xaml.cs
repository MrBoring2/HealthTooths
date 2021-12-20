using HealthyTeeth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : BaseWindow
    {
        public AdministratorWindow()
        {
            InitializeComponent();
        }

        private void ClientsControl_Click(object sender, RoutedEventArgs e)
        {
            var clientsWindow = new ClientsListWindow(false);
            clientsWindow.Show();
            this.Close();
        }

        private void EmployeesControl_Click(object sender, RoutedEventArgs e)
        {
            var employeesWindow = new EmployeesListWindow();
            employeesWindow.Show();
            this.Close();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            UserService.Instance.Logout();
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void ConsumablesControl_Click(object sender, RoutedEventArgs e)
        {
            var consumablesWindow = new ConsumablesListWindow();
            consumablesWindow.Show();
            this.Close();
        }

        private void OrderConsumables_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderConsumables();
            orderWindow.Show();
            this.Close();
        }
    }
}
