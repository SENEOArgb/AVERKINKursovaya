using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaMAIN.Model
{
    public class Equipments : INotifyPropertyChanged
    {
        public int equipmentId {  get; set; }

        
        private string equipmentName { get; set; }

        public string EquipmentName
        {
            get { return equipmentName; }
            set
            {
                equipmentName = value;
                OnPropertyChanged("EquipmentName");
            }
        }

        
        private string? equipmentCategory { get; set; }

        public string? EquipmentCategory
        {
            get { return equipmentCategory; }
            set
            {
                equipmentCategory = value;
                OnPropertyChanged("EquipmentCategory");
            }
        }

        
        private string? manufacturerEquipment { get; set; }

        public string? ManufacturerEquipment
        {
            get { return manufacturerEquipment; }
            set
            {
                manufacturerEquipment = value;
                OnPropertyChanged("ManufacturerEquipment");
            }
        }

        
        private string? countryManufactureEquipment { get; set; }

        public string? CountryManufactureEquipment
        {
            get { return countryManufactureEquipment; }
            set
            {
                countryManufactureEquipment = value;
                OnPropertyChanged("CountryManufactureEquipment");
            }
        }

        
        private int? yearManufactureEquipment { get; set; }

        public int? YearManufactureEquipment
        {
            get { return yearManufactureEquipment; }
            set
            {
                yearManufactureEquipment = value;
                OnPropertyChanged("YearManufactureEquipment");
            }
        }

        
        private string? serialNumberEquipment { get; set; }

        public string? SerialNumberEquipment
        {
            get { return serialNumberEquipment; }
            set
            {
                serialNumberEquipment = value;
                OnPropertyChanged("SerialNumberEquipment");
            }
        }

        
        private double? weightEquipment { get; set; }

        public double? WeightEquipment
        {
            get { return weightEquipment; }
            set
            {
                weightEquipment = value;
                OnPropertyChanged("WeightEquipment");
            }
        }

        
        private string? materialEquipment { get; set; }

        public string? MaterialEquipment
        {
            get { return materialEquipment; }
            set
            {
                materialEquipment = value;
                OnPropertyChanged("MaterialEquipment");
            }
        }

        
        private string? equipmentSize { get; set; }

        public string? EquipmentSize
        {
            get { return equipmentSize; }
            set
            {
                equipmentSize = value;
                OnPropertyChanged("EquipmentSize");
            }
        }

        
        private string? color {  get; set; }

        public string? Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        
        private int equipmentPrice { get; set; }

        public int EquipmentPrice
        {
            get { return equipmentPrice; }
            set
            {
                equipmentPrice = value;
                OnPropertyChanged("EquipmentPrice");
            }
        }

        public List<Weapons_Equipments_Consumable_OrdersDPO> Wpn_Eqmt_Cnle_Ord { get; set; }// = new();

        public Equipments() { }

        public Equipments(int equipmentId, string equipmentName, string? equipmentCategory, string? manufacturerEquipment, string? countryManufactureEquipment, int? yearManufactureEquipment,
                          string? serialNumberEquipment, double? weightEquipment, string? materialEquipment, string? equipmentSize, string? color, int equipmentPrice)
        {
            this.equipmentId = equipmentId;
            this.EquipmentName = equipmentName;
            this.EquipmentCategory = equipmentCategory;
            this.ManufacturerEquipment = manufacturerEquipment;
            this.CountryManufactureEquipment = countryManufactureEquipment;
            this.YearManufactureEquipment = yearManufactureEquipment;
            this.SerialNumberEquipment = serialNumberEquipment;
            this.WeightEquipment = weightEquipment;
            this.MaterialEquipment = materialEquipment;
            this.EquipmentSize = equipmentSize;
            this.Color = color;
            this.EquipmentPrice = equipmentPrice;
        }

        public Equipments ShallowCopy()
        {
            return (Equipments)this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
