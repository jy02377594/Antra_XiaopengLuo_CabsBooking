using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<BookingAddRequestDto> GetBookingById(int bId);
        Task<IEnumerable<BookingModel>> GetAllBookings();
        void AddBooking(BookingAddRequestDto booking);
        void UpdateBooking(BookingAddRequestDto booking);
        void DeleteBooking(int bId);
    }
}
