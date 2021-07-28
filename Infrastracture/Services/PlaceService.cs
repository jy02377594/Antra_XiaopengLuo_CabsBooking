using ApplicationCore;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastracture.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public void AddPlace(PlacesModel places)
        {
            var entity = new Places()
            {
                PlaceId = places.PlaceId,
                PlaceName = places.PlaceName
            };

            _placeRepository.AddPlace(entity);
        }

        public void DeletePlace(PlacesModel places)
        {
            var entity = new Places()
            {
                PlaceId = places.PlaceId,
                PlaceName = places.PlaceName
            };

            _placeRepository.DeletePlace(entity);
        }

        public async Task<IEnumerable<PlacesModel>> GetAllPlaces()
        {
            var entities = await _placeRepository.GetAllPlaces();
            var models = new List<PlacesModel>();
            foreach (var entity in entities)
            {
                models.Add(new PlacesModel
                {
                    PlaceId = entity.PlaceId,
                    PlaceName = entity.PlaceName
                });
            }

            return models;
        }

        public async Task<PlacesModel> GetPlaceById(int pId)
        {
            var entity = await _placeRepository.GetPlaceById(pId);
            return new PlacesModel()
            {
                PlaceId = entity.PlaceId,
                PlaceName = entity.PlaceName
            };
        }

        public void UpdatePlace(PlacesModel places)
        {
            var entity = new Places()
            {
                PlaceId = places.PlaceId,
                PlaceName = places.PlaceName
            };

            _placeRepository.UpdatePlace(entity);
        }
    }
}
