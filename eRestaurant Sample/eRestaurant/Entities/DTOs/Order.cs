using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities.DTOs
{
    public class Order
    {
        public int TableNumber { get; set; }
        public string Waiter { get; set; }
        public int WaiterID { get; set; }
        public int? BillID { get; set; }
        public bool Served { get; set; }
        public string OrderComments { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
