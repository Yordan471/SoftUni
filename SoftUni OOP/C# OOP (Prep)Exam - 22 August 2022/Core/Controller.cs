using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private IRepository<IHotel> hotels = new HotelRepository();

        public Controller()
        {
            this.hotels = new HotelRepository();
        }
        
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel;

            if (hotels.Select(hotelName) != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);              
            }

            hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotels.All().FirstOrDefault(h => h.Category == category) ==  null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            var orderedHotels = hotels.All()
                .Where(h => h.Category == category)
                .OrderBy(h => h.Turnover)
                .ThenBy(h => h.FullName);

            foreach (var hotel in orderedHotels)
            {
                var neededRoom = hotel.Rooms.All()
                    .Where(r => r.PricePerNight > 0)
                    .OrderBy(r => r.BedCapacity)
                    .FirstOrDefault(r => r.BedCapacity >= children + adults);

                if (neededRoom != null)
                {
                    int bookingNumber = hotel.Bookings.All().Count() + 1;
                    IBooking booking = new Booking(neededRoom, duration, adults, children, bookingNumber);
                    hotel.Bookings.AddNew(booking);
                    return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                }
            }

            return string.Format(OutputMessages.RoomNotAppropriate);
        }

        public string HotelReport(string hotelName)
        {          
            if (hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotels.Select(hotelName);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover {hotel.Turnover:f2} $");
            sb.AppendLine($"--Bookings:");

            if (hotel.Bookings.All().Count() != 0)
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();

                    //sb.AppendLine($"Booking number: {booking.BookingNumber}");
                    //sb.AppendLine($"Room type: {booking.Room.GetType().Name}");
                    //sb.AppendLine($"Adults :{})
                }           
            }
            else
            {
                sb.AppendLine($"none");
            }

            return sb.ToString().Trim();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotels.Select(hotelName);
            if (roomTypeName != nameof(DoubleBed) &&
                roomTypeName != nameof(Apartment) &&
                roomTypeName != nameof(Studio))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            
            if (hotel.Rooms.Select(roomTypeName) == null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
            }

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotels.Select(hotelName);
            if (hotel.Rooms.Select(roomTypeName) != default)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
            
            if (roomTypeName != nameof(DoubleBed) && 
                roomTypeName != nameof(Apartment) &&
                roomTypeName != nameof(Studio))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = null;
            if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }

            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName ,hotelName);
        }
    }
}
