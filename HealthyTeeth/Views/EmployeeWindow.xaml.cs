
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
        public readonly bool isEdit = false;
        private string fullName;
        private string selectedGender;
        private DateTime dateOfBirth;
        private string passportNumber;
        private string passpordSeries;
        private string phoneNumber;
        private string secretNumber;
        private string cabinetNumber;
        private Visibility administratorRoleVisibility;
        private Visibility doctorRoleVisibility;
        private Role selectedRole;
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
            isEdit = true;
            Employee = employee;
            FullName = employee.FullName;
            SelectedGender = employee.Gender;
            DateOfBirth = employee.DateOfBirth;
            PassportNumber = employee.PassportNumber;
            PassportSeries = employee.PassportSeries;
            PhoneNumber = employee.PhoneNumber;
            selectedRole = employee.Role;
            SwitchRole(SelectedRole);
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
            get => cabinetNumber;
            set
            {
                cabinetNumber = value;
                OnPropertyChanged();
            }
        }

        public string CabinetNumber
        {
            get => cabinetNumber;
            set
            {
                cabinetNumber = value;
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
                SwitchRole(SelectedRole);
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
                if(Employee is Doctor d)
                {
                    d.Cabinet.CabinetNumber = Convert.ToInt32(CabinetNumber);
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
        private async void LoadRoles()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/Roles");
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Roles = JsonConvert.DeserializeObject<ObservableCollection<Role>>(response.Content);
                selectedRole = Roles.FirstOrDefault();
                DataContext = this;
                InitializeComponent();
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
                        var d = typeof(Employee);
                        CabinetNumber = (Employee as Doctor).Cabinet.CabinetNumber.ToString();
                    }
                    break;
                case 3:
                    {
                        DoctorRoleVisibility = Visibility.Hidden;
                        AdministratorRoleVisibility = Visibility.Visible;
                        SecretNumber = (Employee as Administrator).PersonalKey;
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
                DateOfBirth != null;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
