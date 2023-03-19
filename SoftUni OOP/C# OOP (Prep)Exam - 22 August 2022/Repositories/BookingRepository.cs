using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly ICollection<IBooking> bookings;

        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return (IReadOnlyCollection<IBooking>)bookings;
        }

        public IBooking Select(string criteria)
        {
            return bookings.FirstOrDefault(b => b.BookingNumber.ToString() == criteria);
        }
    }
}
