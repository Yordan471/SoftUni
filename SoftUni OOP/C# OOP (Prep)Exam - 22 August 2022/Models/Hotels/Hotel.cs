using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const int minValueCategory = 1;
        private const int maxValueCategory = 5;

        private string fullName;
        private int category;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.Rooms = new RoomRepository();
            this.Bookings = new BookingRepository();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNullOrEmpty);
                }

                fullName = value;
            }
        }

        public int Category
        {
            get => category;
            private set
            {
                if (value < minValueCategory || value > maxValueCategory)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCategory));
                }

                category = value;
            }
        }

        public double Turnover => Math.Round(Bookings.All().Sum(b => b.ResidenceDuration * b.Room.PricePerNight), 2);

        public IRepository<IRoom> Rooms { get; set; }

        public IRepository<IBooking> Bookings { get; set; }
    }
}
