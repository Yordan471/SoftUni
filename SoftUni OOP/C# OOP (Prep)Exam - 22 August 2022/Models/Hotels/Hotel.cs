using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
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
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.rooms = new RoomRepository();
            this.bookings = new BookingRepository();
        }

        public string FullName
        {
            get => fullName;
            set
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
            set
            {
                if (value < minValueCategory || value > maxValueCategory)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }

                category = value;
            }
        }

        public double Turnover => Math.Round(Bookings.All().Sum(b => b.ResidenceDuration * b.Room.PricePerNight), 2);

        public IRepository<IRoom> Rooms => rooms;

        public IRepository<IBooking> Bookings => bookings;
    }
}
