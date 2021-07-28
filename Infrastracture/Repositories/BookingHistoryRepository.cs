using ApplicationCore;
using ApplicationCore.RepositoryInterfaces;
using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repositories
{
    public class BookingHistoryRepository : CommonAsyncRepository<BookingsHistory>, IBookingHistoryRepository
    {
        public BookingHistoryRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }

        public void AddBookingHistory(BookingsHistory bookingshistory)
        {
            Add(bookingshistory);
            _dbContext.SaveChanges();
        }

        public void DeleteBookingHistory(int bhId)
        {
            var bookingHistory = _dbContext.BookingsHistories.FirstOrDefault(bh => bh.id == bhId);
            Delete(bookingHistory);
        }

        public async Task<IEnumerable<BookingsHistory>> GetAllBookingsHistory()
        {
            return await GetAllAsync();
        }

        public async Task<BookingsHistory> GetBookingHistoryById(int bhId)
        {
            return await _dbContext.BookingsHistories.AsNoTracking().FirstOrDefaultAsync(bh => bh.id == bhId);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public void UpdateBookingHistory(BookingsHistory bookingshistory)
        {
            _dbContext.Entry(bookingshistory).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
