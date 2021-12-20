using HealthyToothsModels;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HealthyTeeth.Views
{
    /// <summary>
    /// Логика взаимодействия для VisitWindow.xaml
    /// </summary>
    public partial class VisitWindow : BaseWindow
    {
        private string clientFullName;
        private DateTime visitDate;

        private SpendConsumable selectedConsumable;
        private SpendConsumable selectedSpendConsumable;
        private VisitType selectedType;
        private ObservableCollection<VisitType> visitTypes;
        private Storage selectedStorage;
        private ObservableCollection<SpendConsumable> displayedConsumables;
        private ObservableCollection<SpendConsumable> spendedConsumables;
        private ObservableCollection<Storage> storages;
        public VisitWindow(Record record)
        {
            InitializeComponent();
            LoadConsumables();
            LoadTypes();
            LoadStorages();
            CurrentRecord = record;
            VisitDate = record.RecordDate;
            ClientFullName = record.ClientFullName;
            DataContext = this;
            SpendedConsumables = new ObservableCollection<SpendConsumable>();

        }
        public SpendConsumable SelectedSpendConsumable
        {
            get => selectedSpendConsumable;
            set
            {
                selectedSpendConsumable = value;
                OnPropertyChanged();
            }
        }
        public SpendConsumable SelectedConsumable
        {
            get => selectedConsumable;
            set
            {
                selectedConsumable = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Storage> Storages
        {
            get => storages;
            set
            {
                storages = value;
                OnPropertyChanged();
            }
        }
        public Storage SelectedStorage
        {
            get => selectedStorage;
            set
            {
                selectedStorage = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<SpendConsumable> Consumables { get; set; }
        public DateTime VisitDate
        {
            get => visitDate;
            set
            {
                visitDate = value;
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
        public ObservableCollection<VisitType> VisitTypes
        {
            get => visitTypes;
            set
            {
                visitTypes = value;
                OnPropertyChanged();
            }
        }
        public VisitType SelectedType
        {
            get => selectedType;
            set
            {
                selectedType = value;
                OnPropertyChanged();
            }
        }
        public ClientsVisit Visit { get; set; }
        public Record CurrentRecord { get; set; }
        public ObservableCollection<SpendConsumable> DisplayedConsumables
        {
            get => displayedConsumables;
            set
            {
                displayedConsumables = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<SpendConsumable> SpendedConsumables
        {
            get => spendedConsumables;
            set
            {
                spendedConsumables = value;
                OnPropertyChanged();
            }
        }

        private async void LoadConsumables()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/Consumables");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                Consumables = new ObservableCollection<SpendConsumable>();
                var list = JsonConvert.DeserializeObject<ObservableCollection<Consumable>>(response.Content);
                list.ToList().ForEach(p => Consumables.Add(new SpendConsumable { Consumable = p, ConsumableAmount = 0 }));
                DisplayedConsumables = Consumables;
            }
        }
        private async void LoadStorages()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/Storages");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Storages = JsonConvert.DeserializeObject<ObservableCollection<Storage>>(response.Content);
                SelectedStorage = Storages.FirstOrDefault();
            }
        }
        private async void LoadTypes()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/VisitTypes");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                VisitTypes = JsonConvert.DeserializeObject<ObservableCollection<VisitType>>(response.Content);
                SelectedType = VisitTypes.FirstOrDefault();
            }
        }

        private void AddToList_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedConsumable != null)
            {
                if (SelectedConsumable.ConsumableAmount > 0)
                {
                    if (SpendedConsumables.FirstOrDefault(p => p.ConsumableName.Equals(SelectedConsumable.ConsumableName)) == null)
                    {
                        SpendedConsumables.Add(SelectedConsumable);
                    }
                    else
                    {
                        CustomMessageBox.Show("Данный расходник уже есть в списке!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    CustomMessageBox.Show("Количетсво расходника должно быть больше 0!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                CustomMessageBox.Show("Сначала выберите расходник!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveFromList_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedSpendConsumable != null)
            {
                SpendedConsumables.Remove(SelectedSpendConsumable);
            }
            else
            {
                CustomMessageBox.Show("Сначала выберите расходник!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var doctorWindow = new DoctorWindow();
            doctorWindow.Show();
            this.Close();
        }

        private void CreateVisit_Click(object sender, RoutedEventArgs e)
        {
            //if (Validate())
            //{
            Visit = new ClientsVisit
            {
                ClientId = CurrentRecord.ClientId,
                DoctorId = UserService.Instance.Employee.EmployeeId,
                VisitDate = VisitDate.ToLocalTime(),
                VisitTypeId = SelectedType.VisitTypeId,
                SpentConsumablesForVisits = new List<SpentConsumablesForVisit>()
            };
            foreach (var consumable in SpendedConsumables)
            {
                Visit.SpentConsumablesForVisits.Add(
                    new SpentConsumablesForVisit
                    {
                        СonsumableId = consumable.Consumable.ConsumableId,
                        Amount = consumable.ConsumableAmount
                    });
            }

            this.DialogResult = true;
            // }
        }

        //private bool Validate()
        //{
        //    if (VisitDate != null &&  DateTime.Now.Date <= VisitDate.Date)
        //    {
        //        return true;
        //    }
        //    else
        //    {

        //        CustomMessageBox.Show("Запись не на сегодняшний день!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return false;
        //    }
        //}
    }
}