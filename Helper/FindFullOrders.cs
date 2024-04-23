using KursovayaMAIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaMAIN.Helper
{
    public class FindFullOrders
    {
        int Id;
        public FindFullOrders(int Id)
        {
            this.Id = Id;
        }

        public bool FullOrdersPredicate(Weapons_Equipments_Consumables_Orders fullorders)
        {
            return fullorders.weaponsEquipmentsConsumablesOrdersId == Id;
        }
    }
}
