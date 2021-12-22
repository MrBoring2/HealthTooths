using HealthyTeeth.Services;
using HealthyToothsModels;
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
using HealthyTeeth.Models;

namespace HealthyTeeth.Views
{
    /// <summary>
    /// Логика взаимодействия для ConsumablesListWindow.xaml
    /// </summary>
    public partial class ConsumablesListWindow : BaseWindow
    {
        private int itemsPerPage;
        private string search;
        private bool isAscending;
        private bool isDescending;
        private ObservableCollection<Consumable> displayedConsumables;
        private ObservableCollection<string> types;
        private SortParameter selectedSort;
        private Consumable selectedConsumable;
        private Visibility emptyVisibility;
        private string selectedType;
        public ConsumablesListWindow()
        {
            InitializeFields();

        }
        public List<string> Genders { get; set; }
        public string SelectedType
        {
            get => selectedType;
            set
            {
                selectedType = value;
                RefreshConsumables();
                OnPropertyChanged();
            }
        }
        public SortParameter SelectedSort
        {
            get => selectedSort;
            set
            {
                selectedSort = value;
                RefreshConsumables();
                OnPropertyChanged();
            }
        }
        public Paginator Paginator { get; set; }
        public List<SortParameter> SortParameters { get; set; }
        public ObservableCollection<Consumable> Consumables { get; set; }
        public ObservableCollection<string> Types
        {
            get => types;
            set
            {
                types = value;
                OnPropertyChanged();
            }
        }
        public Consumable SelectedConsumable
        {
            get => selectedConsumable;
            set
            {
                selectedConsumable = value;
            }
        }
        public ObservableCollection<Consumable> DisplayedConsumables
        {
            get => displayedConsumables;
            set
            {
                displayedConsumables = value;
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
                if (Consumables != null)
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
                if (Consumables != null)
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



        private void InitializeFields()
        {
            search = "";
            SortParameters = new List<SortParameter>
            {
                new SortParameter("Название", "ConsumableName"),
                new SortParameter("Цена", "Price")
            };
            selectedSort = SortParameters.FirstOrDefault();
            EmptyVisibility = Visibility.Hidden;

            //Измените это для отображения количетсва элементов на странице
            ItemsPerPage = 10;
            LoadConsumables();
        }
        private async void LoadTypes()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/ConsumableTypes");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Types = new ObservableCollection<string> { "Все" };
                var typesList = JsonConvert.DeserializeObject<ObservableCollection<ConsumableType>>(response.Content);
                typesList.ToList().ForEach(p => Types.Add(p.ConsumableTypeName));
                selectedType = Types.FirstOrDefault();
                isAscending = true;
                isDescending = false;

                Paginator = new Paginator(5, MaxPage());
                RefreshConsumables();
                InitializeComponent();
                DataContext = this;
            }
        }
        private async void LoadConsumables()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/Consumables");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Consumables = JsonConvert.DeserializeObject<ObservableCollection<Consumable>>(response.Content);
                LoadTypes();

                UserService.Instance.HubConnection.On<string>("UpdateConsumables", (employees) =>
                {
                    Consumables = JsonConvert.DeserializeObject<ObservableCollection<Consumable>>(employees);
                    RefreshConsumables();
                });
            }
        }


        /// <summary>
        /// Сортировка записей
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        private IEnumerable<Consumable> SortConsumables(IEnumerable<Consumable> consumables)
        {
            if (IsDescending)
            {
                //Сортируем по убыванию
                consumables = consumables.OrderByDescending(p => p.GetProperty(SelectedSort.Property));
            }
            else
            {
                //Сортируем по возрастанию
                consumables = consumables.OrderBy(p => p.GetProperty(SelectedSort.Property));
            }
            return consumables;
        }

        /// <summary>
        /// Метод обновления списка записей
        /// </summary>
        private void RefreshConsumables()
        {
            //Сортируем список
            var list = SortConsumables(Consumables).ToList();
            //Фильтруем список по поисковой строке
            list = list.Where(p => p.ConsumableName.ToLower().Contains(Search.ToLower())).ToList();

            //Фильтруем список клиентов по ролям
            list = list.Where(p => SelectedType != "Все" ? p.ConsumableType.ConsumableTypeName == SelectedType : p.ConsumableType.ConsumableTypeName.Contains("")).ToList();

            //Выбираем записи начиная с SelectedPageNumber умноженного на itemsPerPage и берём itemsPerPage
            list = list.Skip((Paginator.SelectedPageNumber - 1) * itemsPerPage)
               .Take(itemsPerPage).ToList();

            //Устанавливаем список для отображения
            DisplayedConsumables = new ObservableCollection<Consumable>(list);
            //Обновляем пагинатор
            Paginator.RefreshPages(MaxPage() == 0 ? 1 : MaxPage());

            //Если после фильтрации у нас количество элементов 0, то выводим Пусто
            if (DisplayedConsumables.Count <= 0)
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
            var list = Consumables
                     .Where(p => p.ConsumableName.ToLower().Contains(Search.ToLower())).ToList();

            //Фильтруем список клиентов по ролям
            list = list.Where(p => SelectedType != "Все" ? p.ConsumableType.ConsumableTypeName == SelectedType : p.ConsumableType.ConsumableTypeName.Contains("")).ToList();

            return (int)Math.Ceiling((float)list.Count / (float)ItemsPerPage);
        }

        private async void AddNewConsumable_Click(object sender, RoutedEventArgs e)
        {
            var addConsumableWindow = new ConsumableWindow();
            if (addConsumableWindow.ShowDialog() == true)
            {
                var response = await UserService.Instance.apiService.SendPostRequest("api/Consumables", addConsumableWindow.Consumable);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    CustomMessageBox.Show($"Расходник {addConsumableWindow.ConsumableName} успешно добавлен!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    CustomMessageBox.Show($"Произошла ошибка при добавлении: {response.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ConsumablesList_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            name.Width = (ConsumablesList.ActualWidth / 4) + 50;
            type.Width = (ConsumablesList.ActualWidth / 4) - 10;
            cena.Width = (ConsumablesList.ActualWidth / 4) - 80;
            amount.Width = (ConsumablesList.ActualWidth / 4) - 20;

        }

        private void ConsumablesList_Loaded(object sender, RoutedEventArgs e)
        {
            name.Width = (ConsumablesList.ActualWidth / 4) + 50;
            type.Width = (ConsumablesList.ActualWidth / 4) - 10;
            cena.Width = (ConsumablesList.ActualWidth / 4) - 80;
            amount.Width = (ConsumablesList.ActualWidth / 4) - 20;
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

        private async void EditConsumable_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedConsumable != null)
            {
                var employeeWindow = new ConsumableWindow(SelectedConsumable);
                if (employeeWindow.ShowDialog() == true)
                {
                    var response = await UserService.Instance.apiService.SendPutRequest("api/Consumables", employeeWindow.Consumable.ConsumableId, employeeWindow.Consumable);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        CustomMessageBox.Show($"Расходник {employeeWindow.ConsumableName} успешно изменён!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        CustomMessageBox.Show($"Расходик не найден в базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        CustomMessageBox.Show($"Произошла ошибка при редактировании: {response.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                CustomMessageBox.Show($"Сначала выберите расходник!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void RemoveConsumable_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedConsumable != null)
            {
                var result = CustomMessageBox.Show("Вы точно хотите удалить этот расходник?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var response = await UserService.Instance.apiService.SendDeleteRequest("api/Consumables", SelectedConsumable.ConsumableId);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        CustomMessageBox.Show($"Расходник успешно удалён!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        CustomMessageBox.Show($"Расходник не найден в базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        CustomMessageBox.Show($"Произошла ошибка при удалении: {response.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                CustomMessageBox.Show($"Сначала выберите расходник!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var administratorWindow = new AdministratorWindow();
            administratorWindow.Show();
            this.Close();
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
    }
}

