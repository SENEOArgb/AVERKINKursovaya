using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KursovayaMAIN.ViewModel;

namespace KursovayaMAIN.Model
{
    public class Weapons_Equipments_Consumable_OrdersDPO : INotifyPropertyChanged
    {

        public int weaponsEquipmentsConsumablesOrdersId { get; set; }

        [NotMapped]
        private string? weaponName { get; set; }
        [NotMapped]
        public string? WeaponName
        {
            get { return weaponName; }
            set
            {
                weaponName = value;
                OnPropertyChanged("WeaponName");
            }
        }
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

        public Weapons? Weapon { get; set; }

        [NotMapped]
        private string? equipmentName { get; set; }
        [NotMapped]
        public string? EquipmentName
        {
            get { return equipmentName; }
            set
            {
                equipmentName = value;
                OnPropertyChanged("EquipmentName");
            }
        }
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
        private string? consumableName { get; set; }
        [NotMapped]
        public string? ConsumableName
        {
            get { return consumableName; }
            set
            {
                consumableName = value;
                OnPropertyChanged("ConsumableName");
            }
        }

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
        private int orderId { get; set; }

        public int OrderId
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


        public Weapons_Equipments_Consumable_OrdersDPO() { }

        public Weapons_Equipments_Consumable_OrdersDPO(int WeaponEquipmentConsumableOrderId, string? WeaponName, string? EquipmentName, string? ConsumableName, int OrderID, double OrderCost)
        {
            this.weaponsEquipmentsConsumablesOrdersId = WeaponEquipmentConsumableOrderId;
            this.WeaponName = WeaponName;
            this.EquipmentName = EquipmentName;
            this.ConsumableName = ConsumableName;
            this.OrderId = OrderID;
            this.OrderCost = OrderCost;
        }


        public Weapons_Equipments_Consumable_OrdersDPO CopyFromFullOrders(Weapons_Equipments_Consumables_Orders weco)
        {
            Weapons_Equipments_Consumable_OrdersDPO wecoDPO = new Weapons_Equipments_Consumable_OrdersDPO();
            MainViewModel vmMain = new MainViewModel();
            string weapon = string.Empty;
            foreach (var w in vmMain._weaponList)
            {
                if (w.weaponId == weco.WeaponId)
                {
                    weapon = w.WeaponName;
                    break;
                }
            }
            string equipment = string.Empty;
            foreach (var e in vmMain._equipList)
            {
                if (e.equipmentId == weco.EquipmentId)
                {
                    equipment = e.EquipmentName;
                    break;
                }
            }
            string consumable = string.Empty;
            foreach(var c in vmMain._consList)
            {
                if (c.consumableId == weco.ConsumableId)
                {
                    consumable = c.ConsumableName;
                    break;
                }
            }
            int order = 0;
            foreach (var o in vmMain._shortordersList)
            {
                if(o.orderId == weco.OrderId)
                {
                    order = o.orderId;
                    break;
                }
            }

            double ordercost = 0;
            foreach (var wb in vmMain._fullorderList)
            {
                if (wb.OrderCost == weco.OrderCost)
                {
                    ordercost = wb.OrderCost;
                }
            }
            if (weapon != string.Empty & equipment != string.Empty
                & consumable != string.Empty & order != 0 & ordercost != 0)
            {
                wecoDPO.weaponsEquipmentsConsumablesOrdersId = weco.weaponsEquipmentsConsumablesOrdersId;
                wecoDPO.WeaponName = weapon;
                wecoDPO.EquipmentName = equipment;
                wecoDPO.ConsumableName = consumable;
                wecoDPO.OrderId = order;
                wecoDPO.OrderCost = ordercost;
            }
            return wecoDPO;
        }

        public Weapons_Equipments_Consumable_OrdersDPO ShallowCopy()
        {
            return (Weapons_Equipments_Consumable_OrdersDPO)this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
