using HealthyTeeth.Services;
using HealthyToothsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
        private int selectedHour;
        private string selectedMinute;

        public RecordWindow()
        {
            Hours = new List<int>
            {
                01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,00
            };
            Minutes = new List<string>
            {
                "00", "30"
            };
            SelectedHour = Hours.FirstOrDefault(p => p == DateTime.Now.Hour);
            SelectedMinute = Minutes.FirstOrDefault();
            InitializeComponent();
            DataContext = this;
            RecordDate = DateTime.UtcNow.Date;

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
        public int SelectedHour { get => selectedHour; set { selectedHour = value; OnPropertyChanged(); } }
        public string SelectedMinute { get => selectedMinute; set { selectedMinute = value; OnPropertyChanged(); } }
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
        public List<int> Hours { get; set; }
        public List<string> Minutes { get; set; }
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
                if (RecordDate.Date.ToLocalTime() < DateTime.Now.Date.ToLocalTime())
                {
                    CustomMessageBox.Show("Дата должна быть больше или равная сегоднешнеому дню!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if ((RecordDate.AddHours(SelectedHour).AddMinutes(Convert.ToInt32(SelectedMinute)).Hour < DateTime.Now.Hour))
                {
                    CustomMessageBox.Show("Время должно быть больше или равное текущему времени!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var record = new Record
                {
                    ClientId = Client.ClientId,
                    DoctorId = Doctor.EmployeeId,
                    RecordDate = RecordDate.AddHours(SelectedHour).AddMinutes(Convert.ToInt32(SelectedMinute))
                };

                var response = await APIService.PostRequest("api/Records", record);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    CustomMessageBox.Show("Запись успешно добавлена!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    Client = null;
                    Doctor = null;
                    ClientFullName = string.Empty;
                    DoctorFullName = string.Empty;
                    RecordDate = DateTime.UtcNow.Date;
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
