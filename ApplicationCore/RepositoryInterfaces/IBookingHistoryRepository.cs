using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IBookingHistoryRepository:IAsyncRepository<BookingsHistory>
    {
        Task<BookingsHistory> GetBookingHistoryById(int bhId);
        Task<IEnumerable<BookingsHistory>> GetAllBookingsHistory();
        void AddBookingHistory(BookingsHistory bookingshistory);
        void UpdateBookingHistory(BookingsHistory bookingshistory);
        void DeleteBookingHistory(int bhId);
        Task<bool> SaveAsync();
    }
}
