
using HealthyToothsModels;
using HealthyTeeth.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : BaseWindow
    {
        private string fullName;
        private string selectedGender;
        private DateTime dateOfBirth;
        private string passportNumber;
        private string passpordSeries;
        private string phoneNumber;
        private string login;
        private string password;
        private string secretNumber;
        private Cabinet selectedCabinet;
        private Visibility administratorRoleVisibility;
        private Visibility doctorRoleVisibility;
        private Role selectedRole;
        private ObservableCollection<Cabinet> cabinets;
        private ObservableCollection<Role> roles;

        public EmployeeWindow()
        {
            Genders = new List<string>
            {
                "мужчина",
                "женщина"
            };
            LoadRoles();
            DateOfBirth = DateTime.Now;
            SelectedGender = Genders.FirstOrDefault();
            Employee = new Employee();

        }
        public EmployeeWindow(Employee employee) : this()
        {
            IsOperationAdd = false;
            Employee = employee;
            FullName = employee.FullName;
            SelectedGender = employee.Gender;
            DateOfBirth = employee.DateOfBirth;
            PassportNumber = employee.PassportNumber;
            PassportSeries = employee.PassportSeries;
            PhoneNumber = employee.PhoneNumber;
            Login = employee.Login;
            Password = employee.Password;
        }
        public bool IsOperationAdd { get; set; } = true;
        public ObservableCollection<Cabinet> Cabinets
        {
            get => cabinets;
            set
            {
                cabinets = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Role> Roles
        {
            get => roles;
            set
            {
                roles = value;
                OnPropertyChanged();
            }
        }

        public Visibility AdministratorRoleVisibility
        {
            get => administratorRoleVisibility;
            set
            {
                administratorRoleVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility DoctorRoleVisibility
        {
            get => doctorRoleVisibility;
            set
            {
                doctorRoleVisibility = value;
                OnPropertyChanged();
            }
        }
        public string SecretNumber
        {
            get => secretNumber;
            set
            {
                secretNumber = value;
                OnPropertyChanged();
            }
        }
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        public Cabinet SelectedCabinet
        {
            get => selectedCabinet;
            set
            {
                selectedCabinet = value;
                OnPropertyChanged();
            }
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
        public Role SelectedRole
        {
            get => selectedRole;
            set
            {
                selectedRole = value;
                SetRole(SelectedRole);
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
        public Employee Employee { get; set; }
        public List<string> Genders { get; set; }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (Validate())
            {
                Employee.PassportNumber = PassportNumber;
                Employee.PassportSeries = PassportSeries;
                Employee.DateOfBirth = DateOfBirth.Date;
                Employee.FullName = FullName;
                Employee.Gender = SelectedGender;
                Employee.PhoneNumber = PhoneNumber;
                Employee.Password = Password;
                Employee.Login = Login;

                if (IsOperationAdd)
                {
                    Employee.RoleId = SelectedRole.RoleId;
                }

                if (Employee is Doctor d)
                {
                    d.CabinetId = SelectedCabinet.CabinetId;
                }
                else if (Employee is Administrator a)
                {
                    a.PersonalKey = SecretNumber;
                }
                this.DialogResult = true;
            }
            else
            {
                CustomMessageBox.Show("Не все данные верно заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private async void LoadCabinets()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/Cabinets");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Cabinets = new ObservableCollection<Cabinet>(JsonConvert.DeserializeObject<List<Cabinet>>(response.Content).OrderBy(p => p.CabinetNumber));
                if (Employee == new Employee())
                {
                    SelectedCabinet = Cabinets.FirstOrDefault();
                }
                else
                {
                    SelectedCabinet = (Employee is Doctor d) ? Cabinets.FirstOrDefault(p => p.CabinetId == d.Cabinet.CabinetId) : null;
                }

                DataContext = this;
                InitializeComponent();
            }
        }
        private async void LoadRoles()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/Roles");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Roles = JsonConvert.DeserializeObject<ObservableCollection<Role>>(response.Content);
                selectedRole = Roles.FirstOrDefault();

                if (Employee.Role != null)
                {
                    SwitchRole(Employee.Role);
                }
                else
                {
                    DoctorRoleVisibility = Visibility.Visible;
                    AdministratorRoleVisibility = Visibility.Hidden;
                }
                LoadCabinets();
            }
        }
        private void SwitchRole(Role role)
        {
            switch (role.RoleId)
            {
                case 1:
                    {
                        DoctorRoleVisibility = Visibility.Visible;
                        AdministratorRoleVisibility = Visibility.Hidden;

                        SelectedRole = Roles.FirstOrDefault(p => p.RoleId == 1);
                    }
                    break;
                case 3:
                    {
                        DoctorRoleVisibility = Visibility.Hidden;
                        AdministratorRoleVisibility = Visibility.Visible;
                        SecretNumber = (Employee as Administrator).PersonalKey;
                        SelectedRole = Roles.FirstOrDefault(p => p.RoleId == 3);
                    }
                    break;
                default:
                    {
                        DoctorRoleVisibility = Visibility.Hidden;
                        AdministratorRoleVisibility = Visibility.Hidden;
                    }
                    break;
            }
        }

        private void SetRole(Role role)
        {
            switch (role.RoleId)
            {
                case 1:
                    {
                        DoctorRoleVisibility = Visibility.Visible;
                        AdministratorRoleVisibility = Visibility.Hidden;
                    }
                    break;
                case 3:
                    {
                        DoctorRoleVisibility = Visibility.Hidden;
                        AdministratorRoleVisibility = Visibility.Visible;
                    }
                    break;
                default:
                    {
                        DoctorRoleVisibility = Visibility.Hidden;
                        AdministratorRoleVisibility = Visibility.Hidden;
                    }
                    break;
            }
        }

        private bool Validate()
        {
            return !string.IsNullOrEmpty(FullName) &&
                !string.IsNullOrEmpty(PhoneNumber) &&
                !string.IsNullOrEmpty(PassportNumber) &&
                !string.IsNullOrEmpty(PassportSeries) &&
                DateOfBirth != null &&
                SelectedRole != null &&
                (Employee as Doctor) != null ? SelectedCabinet != null : true &&
                (Employee as Administrator) != null ? !string.IsNullOrEmpty(SecretNumber) : true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
