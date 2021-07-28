using ApplicationCore;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastracture.Services
{
    public class CabService : ICabService
    {
        private readonly ICabRepository _cabRepository;

        public CabService(ICabRepository cabRepository)
        {
            _cabRepository = cabRepository;
        }

        public void AddCab(CabAddModel cab)
        {
            var entity = new CabTypes()
            {
                CabTypeName = cab.CabTypeName
            };

            _cabRepository.AddCab(entity);
        }

        public void DeleteCab(CabModel cab)
        {
            var entity = new CabTypes()
            {
                CabTypeId = cab.CabTypeId,
                CabTypeName = cab.CabTypeName
            };
            _cabRepository.DeleteCab(entity);
        }

        public async Task<IEnumerable<CabModel>> GetAllCabs()
        {

            var entities = await _cabRepository.GetAllCabs();
            var models = new List<CabModel>();

            foreach (var entity in entities)
            {
                models.Add(new CabModel { 
                    CabTypeId = entity.CabTypeId,
                    CabTypeName = entity.CabTypeName
                });
            }

            return models;
        }

        public async Task<CabModel> GetCabById(int cabId)
        {
            var entity = await _cabRepository.GetCabById(cabId);
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            return new CabModel() { 
                CabTypeId = entity.CabTypeId,
                CabTypeName = entity.CabTypeName
            };
        }

        public void UpdateCab(CabModel cab)
        {
            var entity = new CabTypes()
            {
                CabTypeId = cab.CabTypeId,
                CabTypeName = cab.CabTypeName
            };
            _cabRepository.UpdateCab(entity);
        }
    }
}
