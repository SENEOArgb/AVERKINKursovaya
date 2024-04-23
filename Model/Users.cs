using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursovayaMAIN.Model
{
    public class Users : INotifyPropertyChanged
    {
        public int userId { get; set; }

        
        private string userName { get; set; }

        public string NameUser
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("NameUser");
            }
        }

        [NotMapped]
        public string? userSurname { get; set; }

        public string? SurnameUser
        {
            get { return userSurname; }
            set
            {
                userSurname = value;
                OnPropertyChanged("SurnameUser");
            }
        }

        
        private int passportSeries {  get; set; }

        public int SeriesPassport
        {
            get { return passportSeries; }
            set
            {
                passportSeries = value;
                OnPropertyChanged("SeriesPassport");
            }
        }

        
        private int passportNumber { get; set; }

        public int NumberPassport
        {
            get { return passportNumber; }
            set
            {
                passportNumber = value;
                OnPropertyChanged("NumberPassport");
            }
        }

        internal List<Orders> Order { get; set; } //= new();

        public Users() { }

        public Users(int UserId, string UserName, string? UserSurname, int PassportSeries, int PassportNumber)
        {
            this.userId = UserId;
            this.NameUser = UserName;
            this.SurnameUser = UserSurname;
            this.SeriesPassport = PassportSeries;
            this.NumberPassport = PassportNumber;
        }

        public Users ShallowCopy()
        {
            return (Users)this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
