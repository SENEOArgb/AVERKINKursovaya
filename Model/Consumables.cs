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
    public class Consumables : INotifyPropertyChanged
    {
        public int consumableId {  get; set; }

        private string consumableName { get; set; }

        public string ConsumableName
        {
            get { return consumableName; }
            set
            {
                consumableName = value;
                OnPropertyChanged("ConsumableName");
            }
        }

        
        private string? consumableType { get; set; }

        public string? ConsumableType
        {
            get { return consumableType; }
            set
            {
                consumableType = value;
                OnPropertyChanged("ConsumableType");
            }
        }

        
        private int consumablePrice {  get; set; }

        public int ConsumablePrice
        {
            get { return consumablePrice; }
            set
            {
                consumablePrice = value;
                OnPropertyChanged("ConsumablePrice");
            }
        }

        public List<Weapons_Equipments_Consumable_OrdersDPO> Wpn_Eqmt_Cnle_Ord { get; set; }

        public Consumables () { }

        public Consumables (int consumableId, string consumableName, string? consumableType, int consumablePrice)
        {
            this.consumableId = consumableId;
            this.ConsumableName = consumableName;
            this.ConsumableType = consumableType;
            this.ConsumablePrice = consumablePrice;
        }

        public Consumables ShallowCopy()
        {
            return (Consumables)this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
