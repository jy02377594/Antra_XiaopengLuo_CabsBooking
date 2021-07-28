using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface ICabRepository : IAsyncRepository<CabTypes>
    {
        Task<CabTypes> GetCabById(int cabId);
        Task<IEnumerable<CabTypes>> GetAllCabs();
        void AddCab(CabTypes cab);
        void UpdateCab(CabTypes cab);
        void DeleteCab(CabTypes cab);
        Task<bool> SaveAsync();
    }
}
