using HealthyTeeth.Models;
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

namespace HealthyTeeth.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderConsumables.xaml
    /// </summary>
    public partial class OrderConsumables : BaseWindow
    {
        private DeliveryConsumable selectedConsumable;
        private DeliveryConsumable selectedSpendConsumable;
        private Supplier selectedSupplier;
        private ObservableCollection<Supplier> suppliers;
        private Storage selectedStorage;
        private ObservableCollection<DeliveryConsumable> displayedConsumables;
        private ObservableCollection<DeliveryConsumable> spendedConsumables;
        private ObservableCollection<Storage> storages;
        private double totalPrice;
        public OrderConsumables()
        {
            InitializeComponent();
            LoadConsumables();
            LoadSuppliers();
            LoadStorages();
            TotalPrice = 0;
            DataContext = this;
            SpendedConsumables = new ObservableCollection<DeliveryConsumable>();
        }
        public DeliveryConsumable SelectedSpendConsumable
        {
            get => selectedSpendConsumable;
            set
            {
                selectedSpendConsumable = value;
                OnPropertyChanged();
            }
        }
        public DeliveryConsumable SelectedConsumable
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
        public ObservableCollection<DeliveryConsumable> Consumables { get; set; }

        public ObservableCollection<Supplier> Suppliers
        {
            get => suppliers;
            set
            {
                suppliers = value;
                OnPropertyChanged();
            }
        }
        public Supplier SelectedSupplier
        {
            get => selectedSupplier;
            set
            {
                selectedSupplier = value;
                OnPropertyChanged();
            }
        }
        public Delivery Delivery { get; set; }
        public ObservableCollection<DeliveryConsumable> DisplayedConsumables
        {
            get => displayedConsumables;
            set
            {
                displayedConsumables = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<DeliveryConsumable> SpendedConsumables
        {
            get => spendedConsumables;
            set
            {
                spendedConsumables = value;
                OnPropertyChanged();
            }
        }
        public double TotalPrice
        {
            get => totalPrice;
            set
            {
                totalPrice = value;
                OnPropertyChanged();
            }
        }
        private async void LoadConsumables()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/Consumables");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                Consumables = new ObservableCollection<DeliveryConsumable>();
                var list = JsonConvert.DeserializeObject<ObservableCollection<Consumable>>(response.Content);
                list.ToList().ForEach(p => Consumables.Add(new DeliveryConsumable { Consumable = p, ConsumableAmount = 0 }));
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
        private async void LoadSuppliers()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/Suppliers");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Suppliers = JsonConvert.DeserializeObject<ObservableCollection<Supplier>>(response.Content);
                SelectedSupplier = Suppliers.FirstOrDefault();
            }
        }

        private async void Order_Click(object sender, RoutedEventArgs e)
        {
            if (SpendedConsumables.Count > 0)
            {
                Delivery = new Delivery
                {
                    SupplierId = SelectedSupplier.SupplierId,
                    DeliveryDate = DateTime.Now.ToLocalTime(),
                    StorageId = SelectedStorage.StorageId
                };
                foreach (var consumable in SpendedConsumables)
                {
                    Delivery.ConsumablesInDeliveries.Add(
                        new ConsumablesInDelivery
                        {
                            ConsumableId = consumable.Consumable.ConsumableId,
                            Amount = consumable.ConsumableAmount
                        });
                }

                var response = await UserService.Instance.apiService.SendPostRequest("api/Deliveries", Delivery);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    CustomMessageBox.Show("Заказ на доставку успешно оформен!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    CustomMessageBox.Show($"Произошла ошибка при добавлении: {response.ErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                SpendedConsumables.Clear();
                SelectedSpendConsumable = null;
                TotalPrice = 0;
            }
            else
            {
                CustomMessageBox.Show($"В доставке должно быть как минимум 1 расходник!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

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
                        TotalPrice += SelectedConsumable.Price * SelectedConsumable.ConsumableAmount;
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
                TotalPrice -= SelectedConsumable.Price * SelectedConsumable.ConsumableAmount;
            }
            else
            {
                CustomMessageBox.Show("Сначала выберите расходник!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
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
