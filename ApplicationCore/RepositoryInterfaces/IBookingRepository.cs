using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IBookingRepository:IAsyncRepository<Bookings>
    {
        Task<Bookings> GetBookingById(int bId);
        Task<IEnumerable<Bookings>> GetAllBookings();
        void AddBooking(Bookings bookings);
        void UpdateBooking(Bookings bookings);
        void DeleteBooking(int bId);
        Task<bool> SaveAsync();
    }
}
