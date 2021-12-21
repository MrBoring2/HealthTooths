
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
using Microsoft.AspNetCore.SignalR.Client;
using HealthyToothsModels;
using RestSharp;

namespace HealthyTeeth.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeesListWindow.xaml
    /// </summary>
    public partial class EmployeesListWindow : BaseWindow
    {
        private int itemsPerPage;
        private string search;
        private bool isAscending;
        private bool isDescending;
        private ObservableCollection<Employee> displayedEmployees;
        private ObservableCollection<string> roles;
        private string selectedRole;
        private Employee selectedEmployee;
        private Visibility selectVisibility;
        private Visibility emptyVisibility;
        private string selectedGender;
        public EmployeesListWindow(bool isModal)
        {
            InitializeFields(isModal);

        }
        public List<string> Genders { get; set; }
        public string SelectedGender
        {
            get => selectedGender;
            set
            {
                selectedGender = value;
                RefreshConsumables();
                OnPropertyChanged();
            }
        }
        public Paginator Paginator { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
            }
        }
        public ObservableCollection<string> Roles
        {
            get => roles;
            set
            {
                roles = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Role> RolesList { get; set; }
        public string SelectedRole
        {
            get => selectedRole;
            set
            {
                selectedRole = value;
                RefreshConsumables();
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Employee> DisplayedEmployees
        {
            get => displayedEmployees;
            set
            {
                displayedEmployees = value;
                OnPropertyChanged();
            }
        }
        public Visibility SelectVisibility
        {
            get => selectVisibility;
            set
            {
                selectVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility EmptyVisibility
        {
            get => emptyVisibility;
            set
            {
                emptyVisibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsDescending
        {
            get => isDescending;
            set
            {
                isDescending = value;
                if (Employees != null)
                    RefreshConsumables();
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство по возрастанию
        /// </summary>
        public bool IsAscending
        {
            get => isAscending;
            set
            {
                isAscending = value;
                if (Employees != null)
                    RefreshConsumables();
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Свойство поиска
        /// </summary>
        public string Search
        {
            get => search;
            set
            {
                search = value;
                OnPropertyChanged();
                RefreshConsumables();
            }
        }



        private void InitializeFields(bool isModal)
        {
            search = "";
            EmptyVisibility = Visibility.Hidden;
            if (!isModal)
            {
                SelectVisibility = Visibility.Hidden;
            }
            else
            {
                SelectVisibility = Visibility.Visible;
            }
            //Измените это для отображения количетсва элементов на странице
            ItemsPerPage = 10;
            Genders = new List<string>
            {
                "Все",
                "мужчина",
                "женщина"
            };
            LoadEmployees();
        }
        private async void LoadRoles()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/Roles");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Roles = new ObservableCollection<string> { "Все" };
                RolesList = JsonConvert.DeserializeObject<ObservableCollection<Role>>(response.Content);
                RolesList.ToList().ForEach(p => Roles.Add(p.RoleName));
                selectedRole = Roles.FirstOrDefault();
                isAscending = true;
                isDescending = false;
                selectedGender = Genders.FirstOrDefault();

                Paginator = new Paginator(5, MaxPage());
                RefreshConsumables();
                InitializeComponent();
                DataContext = this;
            }
        }
        private async void LoadEmployees()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/Employees");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //var data = response.Content;
                //data = data.Replace("HealthyTeethAPI", "HealthyTeeth");
                //data = data.Replace("Data", "POCO_Classes");
                Employees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(response.Content, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
                });
                var d = Employees.FirstOrDefault() as Doctor;
                LoadRoles();

                UserService.Instance.HubConnection.On<string>("UpdateEmployees", (employees) =>
                {
                    Employees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(employees, new JsonSerializerSettings
                    {
                        
                        TypeNameHandling = TypeNameHandling.Objects,
                        TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
                    });
                    var t = employees;
                    var c = Employees.FirstOrDefault(p=>p.FullName.Equals("Белоусова Ева Дмитриевна")) as Doctor;
                    RefreshConsumables();
                });
            }

        }


        /// <summary>
        /// Сортировка записей
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        private IEnumerable<Employee> SortEmployees(IEnumerable<Employee> employees)
        {
            if (IsDescending)
            {
                //Сортируем по убыванию
                employees = employees.OrderByDescending(p => p.GetProperty("FullName"));
            }
            else
            {
                //Сортируем по возрастанию
                employees = employees.OrderBy(p => p.GetProperty("FullName"));
            }
            return employees;
        }

        /// <summary>
        /// Метод обновления списка записей
        /// </summary>
        private void RefreshConsumables()
        {
            //Сортируем список
            var list = SortEmployees(Employees).ToList();
            //Фильтруем список по поисковой строке
            list = list.Where(p => p.FullName.Contains(Search)).ToList();

            //Фильтруем список клиентов по полу
            list = list.Where(p => SelectedGender != "Все" ? p.Gender.Equals(SelectedGender) : p.Gender.Contains("")).ToList();

            //Фильтруем список клиентов по ролям
            list = list.Where(p => SelectedRole != "Все" ? p.Role.RoleName == SelectedRole : p.Role.RoleName.Contains("")).ToList();

            //Выбираем записи начиная с SelectedPageNumber умноженного на itemsPerPage и берём itemsPerPage
            list = list.Skip((Paginator.SelectedPageNumber - 1) * itemsPerPage)
               .Take(itemsPerPage).ToList();

            //Устанавливаем список для отображения
            DisplayedEmployees = new ObservableCollection<Employee>(list);
            //Обновляем пагинатор
            Paginator.RefreshPages(MaxPage() == 0 ? 1 : MaxPage());

            //Если после фильтрации у нас количество элементов 0, то выводим Пусто
            if (DisplayedEmployees.Count <= 0)
            {
                EmptyVisibility = Visibility.Visible;
                Paginator.SelectedPageNumber = 1;
            }
            else EmptyVisibility = Visibility.Hidden;
        }

        /// <summary>
        /// Метод для нахождения максимального количества страниц
        /// </summary>
        /// <returns></returns>
        private int MaxPage()
        {
            //Фильтруем наш список по поисковой строке
            var list = Employees
                     .Where(p => p.FullName.Contains(Search)).ToList();

            //Фильтруем список клиентов по полу
            list = list.Where(p => SelectedGender != "Все" ? p.Gender.Equals(SelectedGender) : p.Gender.Contains("")).ToList();

            //Фильтруем список клиентов по ролям
            list = list.Where(p => SelectedRole != "Все" ? p.Role.RoleName == SelectedRole : p.Role.RoleName.Contains("")).ToList();

            return (int)Math.Ceiling((float)list.Count / (float)ItemsPerPage);
        }

        private async void AddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            var addEmployeeWindow = new EmployeeWindow();
            if (addEmployeeWindow.ShowDialog() == true)
            {
                var response = new RestResponse();
                var employee = addEmployeeWindow.Employee;
                var admin = new Administrator();
                var doctor = new Doctor();
                if(employee.RoleId == 1)
                {
                    doctor.CabinetId = addEmployeeWindow.SelectedCabinet.CabinetId;
                    doctor.DateOfBirth = employee.DateOfBirth;
                    doctor.FullName = employee.FullName;
                    doctor.Gender = employee.Gender;
                    doctor.Login = employee.Login;
                    doctor.Password = employee.Password;
                    doctor.PassportNumber = employee.PassportNumber;
                    doctor.PassportSeries = employee.PassportSeries;
                    doctor.PhoneNumber = employee.PhoneNumber;
                    doctor.RoleId = employee.RoleId;
                    response = (RestResponse)await UserService.Instance.apiService.SendPostEmployeeRequest("api/Employees", doctor);
                }
                else if(employee.RoleId == 3)
                {
                    admin.DateOfBirth = employee.DateOfBirth;
                    admin.FullName = employee.FullName;
                    admin.Gender = employee.Gender;
                    admin.Login = employee.Login;
                    admin.Password = employee.Password;
                    admin.PassportNumber = employee.PassportNumber;
                    admin.PassportSeries = employee.PassportSeries;
                    admin.PhoneNumber = employee.PhoneNumber;
                    admin.RoleId = employee.RoleId;
                    response = (RestResponse)await UserService.Instance.apiService.SendPostEmployeeRequest("api/Employees", admin);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    CustomMessageBox.Show($"Сотрудник {employee.FullName} успешно добавлен!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    CustomMessageBox.Show($"Произошла ошибка при добавлении: {response.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EmployeesList_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            fio.Width = (EmployeesList.ActualWidth / 5) + 50;
            gender.Width = (EmployeesList.ActualWidth / 5) - 70;
            phoneNumber.Width = (EmployeesList.ActualWidth / 5) - 20;
            role.Width = EmployeesList.ActualWidth / 5 - 70;
            passport.Width = (EmployeesList.ActualWidth / 5) + 15;
        }

        private void EmployeesList_Loaded(object sender, RoutedEventArgs e)
        {
            fio.Width = (EmployeesList.ActualWidth / 5) + 50;
            gender.Width = (EmployeesList.ActualWidth / 5) - 70;
            phoneNumber.Width = (EmployeesList.ActualWidth / 5) - 20;
            role.Width = EmployeesList.ActualWidth / 5 - 70;
            passport.Width = (EmployeesList.ActualWidth / 5) + 15;
        }

        /// <summary>
        /// Кнопка перехода к первой странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToFirst_Click(object sender, RoutedEventArgs e)
        {
            Paginator.SelectedPageNumber = 1;
            Paginator.RefrashPaginator();
        }

        /// <summary>
        /// Кнопка перехода к последней странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToLast_Click(object sender, RoutedEventArgs e)
        {
            Paginator.SelectedPageNumber = Paginator.PagesNumbers.Count;
            Paginator.RefrashPaginator();
        }

        /// <summary>
        /// Событие при изменении выделения страницы в пагинаторе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PagesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Paginator.RefrashPaginator();
            RefreshConsumables();
        }

        private async void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedEmployee != null)
            {
                var employeeWindow = new EmployeeWindow(SelectedEmployee);
                if (employeeWindow.ShowDialog() == true)
                {
                    var response = await UserService.Instance.apiService.SendPutRequest("api/Employees", employeeWindow.Employee.EmployeeId, employeeWindow.Employee);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        CustomMessageBox.Show($"Сотрудник {employeeWindow.FullName} успешно изменён!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        CustomMessageBox.Show($"Сотрудник не найден в базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        CustomMessageBox.Show($"Произошла ошибка при редактировании: {response.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                CustomMessageBox.Show($"Сначала выберите сотрудника!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void RemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedEmployee != null)
            {
                var result = CustomMessageBox.Show("Вы точно хотите удалить этого сотрудника?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var response = await UserService.Instance.apiService.SendDeleteRequest("api/Employees", SelectedEmployee.EmployeeId);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        CustomMessageBox.Show($"Сотрудник успешно удалён!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        CustomMessageBox.Show($"Сотрудник не найден в базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        CustomMessageBox.Show($"Произошла ошибка при удалении: {response.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                CustomMessageBox.Show($"Сначала выберите сотрудника!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Descending_Checked(object sender, RoutedEventArgs e)
        {
            IsDescending = true;
            isAscending = false;
        }

        /// <summary>
        /// RadioButton для отметки, что сортировка по возрастанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ascending_Checked(object sender, RoutedEventArgs e)
        {
            IsAscending = true;
            isDescending = false;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var administratorWindow = new AdministratorWindow();
            administratorWindow.Show();
            this.Close();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedEmployee != null)
            {
                if (SelectedEmployee is Doctor)
                {
                    this.DialogResult = true;
                }
                else
                {
                    CustomMessageBox.Show("Этот сотрудник не является доктором!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                CustomMessageBox.Show("Сначала выберите доктора!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
