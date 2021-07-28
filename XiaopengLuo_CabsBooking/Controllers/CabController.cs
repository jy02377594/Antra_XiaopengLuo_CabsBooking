using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XiaopengLuo_CabsBooking.Controllers
{
    public class CabController : Controller
    {
        private readonly ICabService _cabService;

        public CabController(ICabService cabService)
        {
            _cabService = cabService;
        }
        public async Task<IActionResult> Index()
        {
            var cabs = await _cabService.GetAllCabs();
            return View(cabs);
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAllCabs()
        //{
        //    var cabs = await _cabService.GetAllCabs();
        //    return View(cabs);
        //}
        [HttpGet]
        public async Task<IActionResult> GetCabByCabId(int cId)
        {
            var cab = await _cabService.GetCabById(cId);
            return View(cab);
        }
        [HttpPost]
        public IActionResult AddCab(CabAddModel model) {
            _cabService.AddCab(model);
            return RedirectToAction("Index");
        }

        public IActionResult AddOneCab() {
            return View();
        }

        public async Task<IActionResult> DeleteCab(int cId)
        {
            var cab = await _cabService.GetCabById(cId);
            _cabService.DeleteCab(cab);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateOneCab(int cId) {
            var cab = await _cabService.GetCabById(cId);
            return View(cab);
        }

        public IActionResult UpdateCab(CabModel model, int cId)
        {
            model.CabTypeId = cId;
            _cabService.UpdateCab(model);
            return RedirectToAction("Index");
        }
    }
}
