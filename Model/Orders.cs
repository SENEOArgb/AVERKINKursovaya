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
    public class Orders : INotifyPropertyChanged 
    {
        public int orderId { get; set; }

        //внешний ключ с таблицы Users

        private int? UserId { get; set; }

        public int? userID
        {
            get { return UserId; }
            set
            {
                UserId = value;
                OnPropertyChanged("userID");
            }
        }

        //навигационное свойство
        public Users? Users { get; set; }

        
        private string? orderArticle { get; set; }

        public string? OrderArticle
        {
            get { return orderArticle; }
            set
            {
                orderArticle = value;
                OnPropertyChanged("OrderArticle");
            }
        }
        
        private string? tariffName { get; set; }

        public string? TariffName
        {
            get { return tariffName; }
            set
            {
                tariffName = value;
                OnPropertyChanged("TariffName");
            }
        }
        
        private int tariffPrice { get; set; }

        public int TariffPrice
        {
            get { return tariffPrice; }
            set
            {
                tariffPrice = value;
                OnPropertyChanged("TariffPrice");
            }
        }
        
        private int countBalls { get; set; }

        public int CountBalls
        {
            get { return countBalls; }
            set
            {
                countBalls = value;
                OnPropertyChanged("CountBalls");
            }
        }
        
        private string? orderProcessTime { get; set; }

        public string? OrderProcessTime
        {
            get { return orderProcessTime; }
            set
            {
                orderProcessTime = value;
                OnPropertyChanged("OrderProcessTime");
            }
        }
        
        private string? orderProcessDate { get; set; }

        public string? OrderProcessDate
        {
            get { return orderProcessDate; }
            set
            {
                orderArticle = value;
                OnPropertyChanged("OrderProcessDate");
            }
        }

        public Orders() { }

        public List<Weapons_Equipments_Consumable_OrdersDPO> Wpn_Eqmt_Cnle_Ord { get; set; }

        public Orders(int OrderId, int? UserId, string OrderArticle, string? tariffName, int tariffPrice, int CountBalls,  string? OrderProcessTime, string? OrderProcessDate)
        {
            this.orderId = OrderId;
            this.userID = UserId;
            this.orderArticle = OrderArticle;
            this.tariffName = tariffName;
            this.tariffPrice = tariffPrice;
            this.countBalls = CountBalls;
            this.orderProcessTime = OrderProcessTime;
            this.orderProcessDate = OrderProcessDate;
        }

        public Orders ShallowCopy()
        {
            return (Orders)this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
