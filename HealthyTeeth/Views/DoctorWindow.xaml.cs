using HealthyTeeth.Models;

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
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HealthyToothsModels;

namespace HealthyTeeth.Views
{
    /// <summary>
    /// Логика взаимодействия для DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : BaseWindow
    {
        #region Fields
        /// <summary>
        /// Все поля
        /// </summary>
        private int itemsPerPage;
        private string search;
        private bool isAscending;
        private bool isDescending;
        private DateTime startDate;
        private DateTime endDate;
        private ObservableCollection<Record> records;
        private ObservableCollection<Record> displayedRecords;
        private Visibility emptyVisibility;
        private Record selectedRecord;
        #endregion
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public DoctorWindow()
        {
            InitializeFields();

        }

        /// <summary>
        /// Инициализация полей
        /// </summary>
        private void InitializeFields()
        {
            search = "";
            EmptyVisibility = Visibility.Hidden;
            //Измените это для отображения количетсва элементов на странице
            ItemsPerPage = 20;
            LoadRecords();
            DataContext = this;
       
        }

        #region Properties
        /// <summary>
        /// Полнйы список записей
        /// </summary>
        public ObservableCollection<Record> Records
        {
            get => records;
            set
            {
                records = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<int> DisplayedPages => Paginator.DisplayedPagesNumbers ?? (new ObservableCollection<int>());
        /// <summary>
        /// Список отображаемых записей
        /// </summary>
        public ObservableCollection<Record> DisplayedRecords
        {
            get => displayedRecords;
            set
            {
                displayedRecords = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Выделенная запись
        /// </summary>
        public Record SelectedRecord
        {
            get => selectedRecord;
            set
            {
                selectedRecord = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Пагинатор (список для перехода по страницам)
        /// </summary>
        public Paginator Paginator { get; set; }

        /// <summary>
        /// Свойство отображения элемента Пусто
        /// </summary>
        public Visibility EmptyVisibility
        {
            get => emptyVisibility;
            set
            {
                emptyVisibility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство начального приода
        /// </summary>
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (value <= EndDate)
                {
                    startDate = value;
                    RefreshRecords();
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство начального приода
        /// </summary>
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (value >= StartDate)
                {
                    endDate = value;
                    RefreshRecords();
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство по убыванию
        /// </summary>
        public bool IsDescending
        {
            get => isDescending;
            set
            {
                isDescending = value;
                if (Records != null)
                    RefreshRecords();
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
                if (Records != null)
                    RefreshRecords();
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
                RefreshRecords();
            }
        }
        #endregion

        /// <summary>
        /// Загрузка записей с сервера
        /// </summary>
        private async void LoadRecords()
        {
            var s = UserService.Instance.Token;
            var response = await APIService.GetRequestWithParameter("api/Records/getForDoctor", "doctorId", UserService.Instance.Employee.EmployeeId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //Если данные успешно загружены, то заполняем список данными и инициализируем поля и пагинатор
                Records = JsonConvert.DeserializeObject<ObservableCollection<Record>>(response.Content);
                DisplayedRecords = Records;
                startDate = DateTime.Now;
                endDate = DateTime.Now.AddDays(10);
                Paginator = new Paginator(5, MaxPage());
                isAscending = true;
                isDescending = false;
                RefreshRecords();
                UserService.Instance.HubConnection.On<string>("UpdateRecords", (records) =>
                {
                    Records = JsonConvert.DeserializeObject<ObservableCollection<Record>>(records);
                    RefreshRecords();
                });
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(IsAscending));
                OnPropertyChanged(nameof(IsDescending));

                InitializeComponent();
            }
          
        }

        /// <summary>
        /// Сортировка записей
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        private IEnumerable<Record> SortRecords(IEnumerable<Record> records)
        {
            if (IsDescending)
            {
                //Сортируем по убыванию
                records = records.OrderByDescending(p => p.GetProperty("ClientFullName"));
            }
            else
            {
                //Сортируем по возрастанию
                records = records.OrderBy(p => p.GetProperty("ClientFullName"));
            }
            return records;
        }

        /// <summary>
        /// Метод обновления списка записей
        /// </summary>
        private void RefreshRecords()
        {
            //Сортируем список
            var list = SortRecords(Records).ToList();
            //Фильтруем список по поисковой строке
            list = list.Where(p => p.ClientFullName.Contains(Search)).ToList();

            //Фильтруем список по выбранному периоду
            list = list.Where(p => p.RecordDate.Date >= StartDate.Date && p.RecordDate.Date <= EndDate.Date).ToList();

            //Выбираем записи начиная с SelectedPageNumber умноженного на itemsPerPage и берём itemsPerPage
            list = list.Skip((Paginator.SelectedPageNumber - 1) * itemsPerPage)
               .Take(itemsPerPage).ToList();

            //Устанавливаем список для отображения
            DisplayedRecords = new ObservableCollection<Record>(list);
            //Обновляем пагинатор
            Paginator.RefreshPages(MaxPage() == 0 ? 1 : MaxPage());
            OnPropertyChanged(nameof(DisplayedPages));
            //Если после фильтрации у нас количество элементов 0, то выводим Пусто
            if (DisplayedRecords.Count <= 0)
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
            var list = Records
                     .Where(p => p.ClientFullName.Contains(Search)).ToList();
            //Фильтруем наш список по выбранному периоду
            list = list.Where(p => p.RecordDate.Date >= StartDate.Date && p.RecordDate.Date <= EndDate.Date).ToList();

            return (int)Math.Ceiling((float)list.Count / (float)ItemsPerPage);
        }

        #region UIEventHanlers
        /// <summary>
        /// Событие при изменении ширины списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recordsList_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            fio.Width = recordsList.ActualWidth / 2 - 20;
            dateRecord.Width = recordsList.ActualWidth / 2 - 20;
        }

        /// <summary>
        /// Событие при загрузке списка для установки ширины столбцов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recordsList_Loaded(object sender, RoutedEventArgs e)
        {
            fio.Width = recordsList.ActualWidth / 2 - 20;
            dateRecord.Width = recordsList.ActualWidth / 2 - 20;
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
            RefreshRecords();
        }

        /// <summary>
        /// RadioButton для отметки, что сортировка по убыванию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Кнопка для выхода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            UserService.Instance.Logout();
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Кнопка оформить посещение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void addVisit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRecord != null)
            {
                var visitWindow = new VisitWindow(SelectedRecord);
                if (visitWindow.ShowDialog() == true)
                {
                    var response = await APIService.PostRequestWithParameter("api/ClientsVisits", "storageId", visitWindow.SelectedStorage.StorageId, visitWindow.Visit);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        CustomMessageBox.Show("Посещение успешно оформлено!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        CustomMessageBox.Show($"Не хватает расходников на складе, попросите администратор доставить новые!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        CustomMessageBox.Show($"Произошла ошибка при добавлении: {response.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                CustomMessageBox.Show("Сначал выберите запись!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Кнопка для удаления записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void removeRecord_Click(object sender, RoutedEventArgs e)
        {
            //Проверяем, выбрана ли запись в списке
            if (SelectedRecord != null)
            {
                //Спрашивем, хочет ли пользователь удалить запись
                var result = CustomMessageBox.Show("Вы точно хотите удалить эту запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    //Если да, то отправляем запрос на сервер для удаления записи по Id
                    var response = await APIService.DeleteRequest("api/Records", SelectedRecord.RecordId);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        CustomMessageBox.Show("Запись успешно удалена!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        CustomMessageBox.Show("Данной записи не существует в базе данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        CustomMessageBox.Show($"{response.ErrorMessage}", "Произошла ошибка при удалении", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                CustomMessageBox.Show("Сначала выберите запись для удаления!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
    #endregion
}