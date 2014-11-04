using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities.DTOs
{
    public class ReservationCollection
    {

        public List<ReservationSummary> Reservations { get; set; }
        public TimeSpan SeatingTime { get { return new TimeSpan(Time, 0, 0); } }
        public int Time { get; set; }
    }
}
