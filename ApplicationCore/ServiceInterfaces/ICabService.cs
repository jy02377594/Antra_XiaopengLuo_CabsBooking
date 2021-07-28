using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICabService
    {
        Task<CabModel> GetCabById(int cabId);
        Task<IEnumerable<CabModel>> GetAllCabs();
        void AddCab(CabAddModel cab);
        void UpdateCab(CabModel cab);
        void DeleteCab(CabModel cab);
    }
}
