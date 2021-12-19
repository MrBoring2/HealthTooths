
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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class ClientWindow : BaseWindow
    {
        public readonly bool isEdit = false;
        private string fullName;
        private string selectedGender;
        private DateTime dateOfBirth;
        private string passportNumber;
        private string passpordSeries;
        private string phoneNumber;
        public ClientWindow()
        {
            InitializeComponent();
            Genders = new List<string>
            {
                "мужчина",
                "женщина"
            };
            DateOfBirth = DateTime.Now;
            SelectedGender = Genders.FirstOrDefault();
            Client = new Client();
            DataContext = this;
        }
        public ClientWindow(Client client) : this()
        {
            isEdit = true;
            Client = client;
            FullName = client.ClientFullName;
            SelectedGender = client.ClientGender;
            DateOfBirth = client.ClientDateOfBirth;
            PassportNumber = client.PassportNumber;
            PassportSeries = client.PassportSeries;
            PhoneNumber = client.PhoneNumber;
        }
        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged();
            }
        }
        public string SelectedGender
        {
            get => selectedGender;
            set
            {
                selectedGender = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                dateOfBirth = value;
                OnPropertyChanged();
            }
        }
        public string PassportNumber
        {
            get => passportNumber;
            set
            {
                passportNumber = value;
                OnPropertyChanged();
            }
        }
        public string PassportSeries
        {
            get => passpordSeries;
            set
            {
                passpordSeries = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }
        public Client Client { get; set; }
        public List<string> Genders { get; set; }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (Validate())
            {
                Client.PassportNumber = PassportNumber;
                Client.PassportSeries = PassportSeries;
                Client.ClientDateOfBirth = DateOfBirth.Date;
                Client.ClientFullName = FullName;
                Client.ClientGender = SelectedGender;
                Client.PhoneNumber = PhoneNumber;
                this.DialogResult = true;
            }
            else
            {
                CustomMessageBox.Show("Не все данные верно заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool Validate()
        {
            return !string.IsNullOrEmpty(FullName) &&
                !string.IsNullOrEmpty(PhoneNumber) &&
                !string.IsNullOrEmpty(PassportNumber) &&
                !string.IsNullOrEmpty(PassportSeries) &&
                DateOfBirth != null;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
