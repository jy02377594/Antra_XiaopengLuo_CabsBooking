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
    public class CabRepository : CommonAsyncRepository<CabTypes>, ICabRepository
    {
        public CabRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }

        public void AddCab(CabTypes cab)
        {
            _dbContext.CabTypes.Add(cab);
            _dbContext.SaveChanges();
        }

        public void DeleteCab(CabTypes cab)
        {
            if(cab == null) throw new ArgumentNullException(nameof(cab));
            _dbContext.CabTypes.Remove(cab);
            _dbContext.SaveChanges();
        }

        public void UpdateCab(CabTypes cab)
        {
            //一直保存失败，直到我写了这行代码
            //_dbContext.Entry(cab).Property("CabTypeName").IsModified = true;
            _dbContext.Entry(cab).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<CabTypes>> GetAllCabs()
        {
           return await GetAllAsync();
        }

        public async Task<CabTypes> GetCabById(int cabId)
        {
            var entity = await _dbContext.CabTypes.AsNoTracking().FirstOrDefaultAsync(c => c.CabTypeId == cabId);
            return entity;
        }


        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}
