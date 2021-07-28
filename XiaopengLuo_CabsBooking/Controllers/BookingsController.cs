using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XiaopengLuo_CabsBooking.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _bookingService.GetAllBookings();
            return View(model);
        }

        public async Task<IActionResult> GetBookingByBid(int bId)
        {
            var booking = await _bookingService.GetBookingById(bId);
            return View(booking);
        }

        public IActionResult AddOneBooking() {
            return View();
        }

        public IActionResult AddBooking(BookingAddRequestDto model) {
            _bookingService.AddBooking(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBooking(int bId)
        {
            _bookingService.DeleteBooking(bId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateOneBooking(int bId) {
            var booking = await _bookingService.GetBookingById(bId);
            return View(booking);
        }

        public IActionResult UpdateBooking(BookingAddRequestDto model, int bId)
        {
            model.id = bId;
            _bookingService.UpdateBooking(model);
            return RedirectToAction("Index");
        }
    }
}
