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
    public class PlaceRepository : CommonAsyncRepository<Places>, IPlaceRepository
    {
        public PlaceRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }

        public void AddPlace(Places places)
        {
            Add(places);
            _dbContext.SaveChanges();
        }

        public void DeletePlace(Places places)
        {
            Delete(places);
        }

        public async Task<IEnumerable<Places>> GetAllPlaces()
        {
            return await GetAllAsync();
        }

        public async Task<Places> GetPlaceById(int pId)
        {
            var entity = await _dbContext.Places.AsNoTracking().FirstOrDefaultAsync(p => p.PlaceId == pId);
            return entity;
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public void UpdatePlace(Places places)
        {
            _dbContext.Entry(places).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
