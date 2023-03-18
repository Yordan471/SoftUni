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
        private double pricePerNight;

        public Room(int bedCapacity, double pricePerNight = 0)
        {
            this.BedCapacity = bedCapacity;
        }

        public int BedCapacity
        {
            get => bedCapacity;
            set
            {
                bedCapacity = value;
            }
        }

        public double PricePerNight
        { 
            get => pricePerNight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
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
