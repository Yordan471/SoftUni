using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight = 0;

        public Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
        }

        public int BedCapacity
        {
            get => bedCapacity;
            private set
            {
                bedCapacity = value;
            }
        }

        public double PricePerNight
        { 
            get => pricePerNight;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PricePerNightNegative));
                }

                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            pricePerNight = price;
        }
    }
}
