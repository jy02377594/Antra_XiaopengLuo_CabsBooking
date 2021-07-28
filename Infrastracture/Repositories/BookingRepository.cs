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
    public class BookingRepository : CommonAsyncRepository<Bookings>, IBookingRepository
    {
        public BookingRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }

        public void AddBooking(Bookings bookings)
        {
            Add(bookings);
            _dbContext.SaveChanges();
        }

        public void DeleteBooking(int bId)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.id == bId);
            Delete(booking);
        }

        public async Task<IEnumerable<Bookings>> GetAllBookings()
        {
            return await GetAllAsync();
        }

        public async Task<Bookings> GetBookingById(int bId)
        {
            var entity = await _dbContext.Bookings.AsNoTracking().FirstOrDefaultAsync(b => b.id == bId);
            return entity;
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public void UpdateBooking(Bookings bookings)
        {
            _dbContext.Entry(bookings).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
