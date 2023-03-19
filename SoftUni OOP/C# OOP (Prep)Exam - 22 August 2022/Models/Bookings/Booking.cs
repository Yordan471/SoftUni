using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        IRoom room;
        private int residenceDuration;
        private int adultCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultCount, int childrenCount, int bookingNumber)
        {
            this.room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultCount;
            this.ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;
        }

        public IRoom Room => room;        

        public int ResidenceDuration
        {
            get => residenceDuration;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => adultCount;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }

                adultCount = value;
            }
        }

        public int ChildrenCount
        {
            get => childrenCount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }

                childrenCount = value;
            }
        }

        public int BookingNumber => bookingNumber;

        private double TotalPaid() => Math.Round(this.Room.PricePerNight * this.residenceDuration, 2);

        public string BookingSummary()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {TotalPaid():f2} $");

            return sb.ToString().Trim();
        }
    }
}
