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
    /// Логика взаимодействия для ConsumableWindow.xaml
    /// </summary>
    public partial class ConsumableWindow : BaseWindow
    {
        private string name;
        private ConsumableType selectedType;
        private string price;
        private ObservableCollection<ConsumableType> types;
        public ConsumableWindow()
        {
            LoadTypes();
            Consumable = new Consumable();

        }
        public ConsumableWindow(Consumable consumable) : this()
        {
            IsOperationAdd = false;
            Consumable = consumable;
            ConsumableName = consumable.ConsumableName;
            SelectedType = consumable.ConsumableType;
            Price = consumable.Price.ToString();
             
        }
        public bool IsOperationAdd { get; set; } = true;
        public ObservableCollection<ConsumableType> Types
        {
            get => types;
            set
            {
                types = value;
                OnPropertyChanged();
            }
        }

        public string ConsumableName
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public ConsumableType SelectedType
        {
            get => selectedType;
            set
            {
                selectedType = value;
                OnPropertyChanged();
            }
        }
        public string Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        public Consumable Consumable { get; set; }
        public List<string> Genders { get; set; }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (Validate())
            {
                Consumable.ConsumableName = ConsumableName;
                Consumable.Price = Convert.ToDouble(Price);
                Consumable.ConsumablesInStorages = new List<ConsumablesInStorage>();
                
                if (IsOperationAdd)
                {
                    Consumable.ConsumableTypeId = SelectedType.ConsumableTypeId;
                }
              
                this.DialogResult = true;
            }
            else
            {
                CustomMessageBox.Show("Не все данные верно заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        
        private async void LoadTypes()
        {
            var response = await UserService.Instance.apiService.SendGetRequest("api/ConsumableTypes");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Types = JsonConvert.DeserializeObject<ObservableCollection<ConsumableType>>(response.Content);
                selectedType = Types.FirstOrDefault();
                InitializeComponent();
                DataContext = this;

            }
        }

        private bool Validate()
        {
            return !string.IsNullOrEmpty(ConsumableName) &&
                SelectedType != null &&
                double.TryParse(Price, out double d);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}

