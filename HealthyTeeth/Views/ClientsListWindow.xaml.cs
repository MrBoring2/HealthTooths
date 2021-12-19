
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
using HealthyToothsModels;

namespace HealthyTeeth.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientsListWindow.xaml
    /// </summary>
    public partial class ClientsListWindow : BaseWindow
    {
        private int itemsPerPage;
        private string search;
        private bool isAscending;
        private bool isDescending;
        private ObservableCollection<Client> displayedClients;
        private Client selectedClient;
        private Visibility emptyVisibility;
        private Visibility selectVisibility;
        private string selectedGender;
        public ClientsListWindow(bool isModal)
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
                RefreshClients();
                OnPropertyChanged();
            }
        }
        public Paginator Paginator { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
            }
        }
        public ObservableCollection<Client> DisplayedClients
        {
            get => displayedClients;
            set
            {
                displayedClients = value;
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
        public Visibility SelectVisibility
        {
            get => selectVisibility;
            set
            {
                selectVisibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsDescending
        {
            get => isDescending;
            set
            {
                isDescending = value;
                if (Clients != null)
                    RefreshClients();
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
                if (Clients != null)
                    RefreshClients();
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
                RefreshClients();
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
            LoadClients();
        }

        private async void LoadClients()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/Clients");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(response.Content);
                isAscending = true;
                isDescending = false;
                selectedGender = Genders.FirstOrDefault();
                Paginator = new Paginator(5, MaxPage());
                RefreshClients();
                InitializeComponent();
                DataContext = this;

                UserService.Instance.HubConnection.On<string>("UpdateClients", (clients) =>
                {
                    Clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(clients);
                    RefreshClients();
                });
            }
        }


        /// <summary>
        /// Сортировка записей
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        private IEnumerable<Client> SortClients(IEnumerable<Client> clients)
        {
            if (IsDescending)
            {
                //Сортируем по убыванию
                clients = clients.OrderByDescending(p => p.GetProperty("ClientFullName"));
            }
            else
            {
                //Сортируем по возрастанию
                clients = clients.OrderBy(p => p.GetProperty("ClientFullName"));
            }
            return clients;
        }

        /// <summary>
        /// Метод обновления списка записей
        /// </summary>
        private void RefreshClients()
        {
            //Сортируем список
            var list = SortClients(Clients).ToList();
            //Фильтруем список по поисковой строке
            list = list.Where(p => p.ClientFullName.Contains(Search)).ToList();

            //Фильтруем список клиентов по полу
            list = list.Where(p => SelectedGender != "Все" ? p.ClientGender.Equals(SelectedGender) : p.ClientGender.Contains("")).ToList();

            //Выбираем записи начиная с SelectedPageNumber умноженного на itemsPerPage и берём itemsPerPage
            list = list.Skip((Paginator.SelectedPageNumber - 1) * itemsPerPage)
               .Take(itemsPerPage).ToList();

            //Устанавливаем список для отображения
            DisplayedClients = new ObservableCollection<Client>(list);
            //Обновляем пагинатор
            Paginator.RefreshPages(MaxPage() == 0 ? 1 : MaxPage());

            //Если после фильтрации у нас количество элементов 0, то выводим Пусто
            if (DisplayedClients.Count <= 0)
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
            var list = Clients
                     .Where(p => p.ClientFullName.Contains(Search)).ToList();

            //Фильтруем список клиентов по полу
            list = list.Where(p => SelectedGender != "Все" ? p.ClientGender.Equals(SelectedGender) : p.ClientGender.Contains("")).ToList();

            return (int)Math.Ceiling((float)list.Count / (float)ItemsPerPage);
        }


        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClient != null)
            {
                this.DialogResult = true;
            }
            else
            {
                CustomMessageBox.Show("Сначала выберите клиента!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void AddNewClient_Click(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new ClientWindow();
            if (addClientWindow.ShowDialog() == true)
            {
                var response = await UserService.Instance.apiService.SendPostRequest("api/Clients", addClientWindow.Client);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    CustomMessageBox.Show($"Клиент {addClientWindow.FullName} успешно добавлен!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    CustomMessageBox.Show($"Произошла ошибка при добавлении: {response.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ClientsList_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            fio.Width = ClientsList.ActualWidth / 4 + 50;
            gender.Width = ClientsList.ActualWidth / 4 - 70;
            phoneNumber.Width = ClientsList.ActualWidth / 4 - 30;
            passport.Width = ClientsList.ActualWidth / 4 + 5;
        }

        private void ClientsList_Loaded(object sender, RoutedEventArgs e)
        {
            fio.Width = ClientsList.ActualWidth / 4 + 50;
            gender.Width = ClientsList.ActualWidth / 4 - 70;
            phoneNumber.Width = ClientsList.ActualWidth / 4 - 30;
            passport.Width = ClientsList.ActualWidth / 4 + 5;
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
            RefreshClients();
        }

        private async void EditClient_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClient != null)
            {
                var clientWindow = new ClientWindow(SelectedClient);
                if (clientWindow.ShowDialog() == true)
                {
                    var response = await UserService.Instance.apiService.SendPutRequest("api/Clients", clientWindow.Client.ClientId, clientWindow.Client);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        CustomMessageBox.Show($"Клиент {clientWindow.FullName} успешно изменён!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        CustomMessageBox.Show($"Клиент не найден в базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        CustomMessageBox.Show($"Произошла ошибка при редактировании: {response.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                CustomMessageBox.Show($"Сначала выберите клиента!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private async void RemoveClient_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClient != null)
            {
                var result = CustomMessageBox.Show("Вы точно хотите удалить этого клиента?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var response = await UserService.Instance.apiService.SendDeleteRequest("api/Clients", SelectedClient.ClientId);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        CustomMessageBox.Show($"Клиент успешно удалён!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        CustomMessageBox.Show($"Клиент не найден в базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        CustomMessageBox.Show($"Произошла ошибка при удалении: {response.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                CustomMessageBox.Show($"Сначала выберите клиента!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

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