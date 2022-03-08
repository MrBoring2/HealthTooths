using HealthyTeeth.Services;
using HealthyToothsModels;
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
    /// Логика взаимодействия для RecordWindow.xaml
    /// </summary>
    public partial class RecordWindow : BaseWindow
    {
        private string clientFullName;
        private string doctorFullName;
        private DateTime recordDate;

        public RecordWindow()
        {
            InitializeComponent();
            DataContext = this;
            RecordDate = DateTime.Now;
        }
        public DateTime RecordDate
        {
            get => recordDate;
            set
            {
                recordDate = value;
                OnPropertyChanged();
            }
        }
        public string ClientFullName
        {
            get => clientFullName;
            set
            {
                clientFullName = value;
                OnPropertyChanged();
            }
        }
        public string DoctorFullName
        {
            get => doctorFullName;
            set
            {
                doctorFullName = value;
                OnPropertyChanged();
            }
        }
        public Client Client { get; set; }
        public Doctor Doctor { get; set; }

        private void SelectClient_Click(object sender, RoutedEventArgs e)
        {
            var clientsListWindow = new ClientsListWindow(true);
            if (clientsListWindow.ShowDialog() == true)
            {
                Client = clientsListWindow.SelectedClient;
                ClientFullName = Client.ClientFullName;
            }
        }
        private void SelectDoctor_Click(object sender, RoutedEventArgs e)
        {
            var emoloyeesListWindow = new EmployeesListWindow(true);
            if (emoloyeesListWindow.ShowDialog() == true)
            {
                Doctor = emoloyeesListWindow.SelectedEmployee as Doctor;
                DoctorFullName = Doctor.FullName;

            }
        }
        /// <summary>
        /// Создать запись
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CreateRecord_Click(object sender, RoutedEventArgs e)
        {
            if (Doctor != null && Client != null)
            {
                if (RecordDate.Date.ToLocalTime() <= DateTime.Now.Date.ToLocalTime())
                {
                    CustomMessageBox.Show("Дата должна быть больше или равная сегоднешнеому дню!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (RecordDate.ToLocalTime().Date == DateTime.Now && (RecordDate.Hour > DateTime.Now.Hour))
                {
                    CustomMessageBox.Show("Время должно быть больше или равное текущему времени!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var record = new Record
                {
                    ClientId = Client.ClientId,
                    DoctorId = Doctor.EmployeeId,
                    RecordDate = RecordDate.ToLocalTime()
                };

                var response = await APIService.PostRequest("api/Records", record);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    CustomMessageBox.Show("Запись успешно добавлена!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    Client = null;
                    Doctor = null;
                    ClientFullName = string.Empty;
                    DoctorFullName = string.Empty;
                    RecordDate = DateTime.Now.ToLocalTime();
                }
                else
                {
                    CustomMessageBox.Show($"Произошла ошибка при добавлении: {response.Content}!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                CustomMessageBox.Show("Не все поля заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var administratorWindow = new AdministratorWindow();
            administratorWindow.Show();
            this.Close();
        }
    }
}
