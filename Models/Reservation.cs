using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class Reservation
    {
        public int ID { get; set; }

        public DateTime ReservationDate { get; set; }

        public int ReserverId { get; set; }

        public int ReservedBookId { get; set; }


        // How long is the reservation valid? (in days)
        public int ReservationDuration { get; set; }

        public DateTime ReservationEndDate
        {
            get
            {
                return ReservationDate.AddDays(ReservationDuration);
            }
        }


        //How long should the reserved book be kept till the user arrives?

        public int ReservationKeep { get; set; }


        // Enumerator to hold the Status of the Reservation
        public ReservationStatus Status { get; set; }
    }
        
    public enum ReservationStatus
    {
        Active,
        Expired,
        Fulfilled
    }

}
