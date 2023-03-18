using BookingApp.Core.Contracts;
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

        public string AddHotel(string hotelName, int category)
        {
            if (!(hotels.Select(hotelName).Category == category))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category ,hotel);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            throw new NotImplementedException();
        }

        public string HotelReport(string hotelName)
        {
            throw new NotImplementedException();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotels.Select(hotelName);
            if (roomTypeName != nameof(DoubleBed) ||
                roomTypeName != nameof(DoubleBed) ||
                roomTypeName != nameof(DoubleBed))
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
            
            if (roomTypeName != nameof(DoubleBed) || 
                roomTypeName != nameof(DoubleBed) ||
                roomTypeName != nameof(DoubleBed))
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
