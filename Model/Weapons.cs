using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaMAIN.Model
{
    public class Weapons : INotifyPropertyChanged
    {
        public int weaponId {  get; set; }

        private string weaponName { get; set;}

        public string WeaponName
        {
            get { return weaponName; }
            set
            {
                weaponName = value;
                OnPropertyChanged("WeaponName");
            }
        }

        private string? weaponCategory { get; set;}

        public string? WeaponCategory
        {
            get { return weaponCategory; }
            set
            {
                weaponCategory = value;
                OnPropertyChanged("WeaponCategory");
            }
        }

        private string? manufacturerWeapon { get; set;}

        public string? ManufacturerWeapon
        {
            get { return manufacturerWeapon; }
            set
            {
                manufacturerWeapon = value;
                OnPropertyChanged("ManufacturerWeapon");
            }
        }

        private string? countryManufactureWeapon { get; set;}

        public string? CountryManufactureWeapon
        {
            get { return countryManufactureWeapon; }
            set
            {
                countryManufactureWeapon = value;
                OnPropertyChanged("CountryManufactureWeapon");
            }
        }

        private string? combatCaliber {  get; set;}

        public string? CombatCaliber
        {
            get { return combatCaliber; }
            set
            {
                combatCaliber = value;
                OnPropertyChanged("СombatCaliber");
            }
        }

        private int? yearManufactureWeapon { get; set;}

        public int? YearManufactureWeapon
        {
            get { return yearManufactureWeapon; }
            set
            {
                yearManufactureWeapon = value;
                OnPropertyChanged("YearManufactureWeapon");
            }
        }

        private string? serialNumberWeapon { get; set;}

        public string? SerialNumberWeapon
        {
            get { return serialNumberWeapon; }
            set
            {
                serialNumberWeapon = value;
                OnPropertyChanged("SerialNumberWeapon");
            }
        }

        private double? weightWeapon { get; set;}

        public double? WeightWeapon
        {
            get { return weightWeapon; }
            set
            {
                weightWeapon = value;
                OnPropertyChanged("WeightWeapon");
            }
        }

        private string? acummulator {  get; set;}

        public string? Acummulator
        {
            get { return acummulator; }
            set
            {
                acummulator = value;
                OnPropertyChanged("Acummulator");
            }
        }

        private int? magazineCapacity { get; set;}

        public int? MagazineCapacity
        {
            get { return magazineCapacity; }
            set
            {
                magazineCapacity = value;
                OnPropertyChanged("MagazineCapacity");
            }
        }

        private string? materialWeapon { get; set;}

        public string? MaterialWeapon
        {
            get { return materialWeapon; }
            set
            {
                materialWeapon = value;
                OnPropertyChanged("MaterialWeapon");
            }
        }

        private int? firingRate { get; set;}

        public int? FiringRate
        {
            get { return firingRate; }
            set
            {
                firingRate = value;
                OnPropertyChanged("FiringRate");
            }
        }

        private int weaponPrice { get; set;}

        public int WeaponPrice
        {
            get { return weaponPrice; }
            set
            {
                weaponPrice = value;
                OnPropertyChanged("WeaponPrice");
            }
        }

        public List<Weapons_Equipments_Consumable_OrdersDPO> Wpn_Eqmt_Cnle_Ord { get; set; }// = new();

        public Weapons() { }

        public Weapons(int WeaponID, string WeaponName, string? WeaponCategory, string? ManufacturerWeapon, string? CountryManufactureWeapon, string? CombatCaliber, int? YearManufactureWeapon,
                       string? SerialNumberWeapon, double? WeightWeapon, string? Accumulator, int? MagazineCapacity, string? MaterialWeapon, int? FiringRate, int WeaponPrice)
        {
            this.weaponId = WeaponID;
            this.WeaponName = WeaponName;
            this.WeaponCategory = WeaponCategory;
            this.ManufacturerWeapon = ManufacturerWeapon;
            this.CountryManufactureWeapon = CountryManufactureWeapon;
            this.CombatCaliber = CombatCaliber;
            this.YearManufactureWeapon = YearManufactureWeapon;
            this.SerialNumberWeapon = SerialNumberWeapon;
            this.WeightWeapon = WeightWeapon;
            this.Acummulator = Accumulator;
            this.MagazineCapacity = MagazineCapacity;
            this.MaterialWeapon = MaterialWeapon;
            this.FiringRate = FiringRate;
            this.WeaponPrice = WeaponPrice;
        }

        public Weapons ShallowCopy()
        {
            return (Weapons)this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
