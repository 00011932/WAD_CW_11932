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

        public User Reserver { get; set; }

        public string ReservedBookISBN { get; set; }


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

        // constructor for reservation
        public Reservation(User usr, string ISBN)
        {
            ReservationDate = DateTime.Now;
            this.Reserver = usr;
            this.ReservedBookISBN = ISBN;
            ReservationDuration = 7; ////default value is 7 days
            ReservationKeep = 1; //// default is one day
        }

        public Reservation(User usr, string ISBN, int duration, int keep)
        {
            ReservationDate = DateTime.Now;
            this.Reserver = usr;
            this.ReservedBookISBN = ISBN;
            ReservationDuration = duration;
            ReservationKeep = keep;
        }

        // funciton that reports if the reservation is still "alive"
        //the function returns true only if the status is Active
        public bool IsActive()
        {
            // check if it is not expired and is the status is Active
            if (this.Status == ReservationStatus.Active)
            {
                return true;
            }
            else //// either not active or old
                return false;
        }

        //a method that cancels the reservation due to expiration
        //the method should: 
        //set the status to Expired
        public void CancelReservation()
        {
            Status = ReservationStatus.Expired;

        }

        //a function that cancels the reservation due to fulfillment
        
        
        //set the status to Fulfilled
        public void FulfillReservation()
        {
            Status = ReservationStatus.Fulfilled;

        }
    }

    public enum ReservationStatus
    {
        Active,
        Expired,
        Fulfilled
    }

}
