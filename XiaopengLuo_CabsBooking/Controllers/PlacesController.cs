using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XiaopengLuo_CabsBooking.Controllers
{
    public class PlacesController : Controller
    {
        private readonly IPlaceService _placeService;

        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        public async Task<IActionResult> Index()
        {
            var plcaes = await _placeService.GetAllPlaces();
            return View(plcaes);
        }

        public async Task<IActionResult> GetPlaceByPId(int pId)
        {
            var place = await _placeService.GetPlaceById(pId);
            return View(place);
        }

        public IActionResult AddOnePlace() { 
            return View(); 
        }
        public IActionResult AddPlace(PlacesModel model)
        {
            _placeService.AddPlace(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateOnePlace(int pId)
        {
            var place = await _placeService.GetPlaceById(pId);
            return View(place);
        }

        public IActionResult UpdatePlace(PlacesModel model, int pId)
        {
            model.PlaceId = pId;
            _placeService.UpdatePlace(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePlace(int pId)
        {
            var place = await _placeService.GetPlaceById(pId);
            _placeService.DeletePlace(place);
            return RedirectToAction("Index");
        }
    }
}
