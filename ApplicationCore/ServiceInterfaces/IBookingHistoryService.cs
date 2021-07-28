using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingHistoryService
    {
        Task<BookingHistoryRequestDto> GetBookingHistoryById(int bhId);
        Task<IEnumerable<BookingHistoryModel>> GetAllBookingsHistory();
        void AddBookingHistory(BookingHistoryRequestDto booking);
        void UpdateBookingHistory(BookingHistoryRequestDto booking);
        void DeleteBookingHistory(int bhId);
    }
}
