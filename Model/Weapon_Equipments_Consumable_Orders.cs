using KursovayaMAIN.ViewModel;
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
    public class Weapons_Equipments_Consumables_Orders : INotifyPropertyChanged
    {
        public int weaponsEquipmentsConsumablesOrdersId {  get; set; }

        [NotMapped]
        private int? weaponId { get; set; }

        public int? WeaponId
        {
            get { return weaponId; }
            set
            {
                weaponId = value;
                OnPropertyChanged("WeaponId");
            }
        }

        public Weapons? Weapon {  get; set; }

        [NotMapped]
        private int? equipmentId { get; set; }

        public int? EquipmentId
        {
            get { return equipmentId; }
            set
            {
                equipmentId = value;
                OnPropertyChanged("EquipmentId");
            }
        }

        public Equipments? Equipment { get; set; }

        [NotMapped]
        private int? consumableId { get; set; }

        public int? ConsumableId
        {
            get { return consumableId; }
            set
            {
                consumableId = value;
                OnPropertyChanged("ConsumableId");
            }
        }

        public Consumables? Consumable { get; set; }

        [NotMapped]
        private int? orderId { get; set; }

        public int? OrderId
        {
            get { return orderId; }
            set
            {
                orderId = value;
                OnPropertyChanged("OrderId");
            }
        }

        public Orders? Order { get; set; }

        
        [NotMapped]
        private double _orderCost;
        [NotMapped]
        public double OrderCost
        {
            get { return _orderCost; }
            set
            {
                _orderCost = value;
                OnPropertyChanged("OrderCost");
            }
        }
        

        public Weapons_Equipments_Consumables_Orders() { }

        public Weapons_Equipments_Consumables_Orders(int WeaponEquipmentConsumableOrderId, int? WeaponID, int? EquipmentID, int? ConsumableID, int? OrderID, double OrderCost)
        {
            this.weaponsEquipmentsConsumablesOrdersId = WeaponEquipmentConsumableOrderId;
            this.WeaponId = WeaponID;
            this.EquipmentId = EquipmentID;
            this.ConsumableId = ConsumableID;
            this.OrderId = OrderID;
            this.OrderCost = OrderCost;
        }

        public Weapons_Equipments_Consumables_Orders CopyFromFullOrdersDPO(Weapons_Equipments_Consumable_OrdersDPO wdpo)
        {
            MainViewModel vmMain = new MainViewModel();
            int? wdpoId = 0;
            int? edpoId = 0;
            int? cdpoId = 0;
            int? odpoId = 0;
            double? focdpo = 0;
            foreach (var wn in vmMain._fullorderList)
            {
                if (wn.WeaponName == wdpo.WeaponName & wn.ConsumableName == wdpo.ConsumableName
                    & wn.EquipmentName == wdpo.EquipmentName & wn.OrderId == wdpo.OrderId)
                {
                    wdpoId = wn.WeaponId;
                    edpoId = wn.EquipmentId;
                    cdpoId = wn.ConsumableId;
                    odpoId = wn.OrderId;
                    focdpo = focdpo;
                    break;
                }
            }
            if (wdpoId != 0)
            {
                this.weaponsEquipmentsConsumablesOrdersId = wdpo.weaponsEquipmentsConsumablesOrdersId;
                this.WeaponId = wdpoId;
                this.EquipmentId = edpoId;
                this.ConsumableId = cdpoId;
                this.OrderId = odpoId;
            }
            return this;
        }

        public Weapons_Equipments_Consumables_Orders ShallowCopy()
        {
            return (Weapons_Equipments_Consumables_Orders)this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
