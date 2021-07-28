using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IPlaceRepository: IAsyncRepository<Places>
    {
        Task<Places> GetPlaceById(int pId);
        Task<IEnumerable<Places>> GetAllPlaces();
        void AddPlace(Places places);
        void UpdatePlace(Places places);
        void DeletePlace(Places places);
        Task<bool> SaveAsync();
    }
}
