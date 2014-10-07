using eRestaurant.DAL;
using eRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace eRestaurant.BLL
{
    [DataObject]
    public class ReservationController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> ListSpecialEvents()
        {
            using (var context = new RestaurantContext())
            {
                return context.SpecialEvents.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> GetReservationBySpecialEvent(string eventcode)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                var result = from res in context.Reservations
                             where res.EventCode == eventcode
                             select res;
                return result.ToList();
            }
        }
    }
}
