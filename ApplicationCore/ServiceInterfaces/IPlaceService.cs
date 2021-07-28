using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IPlaceService
    {
        Task<PlacesModel> GetPlaceById(int pId);
        Task<IEnumerable<PlacesModel>> GetAllPlaces();
        void AddPlace(PlacesModel places);
        void UpdatePlace(PlacesModel places);
        void DeletePlace(PlacesModel places);
    }
}
