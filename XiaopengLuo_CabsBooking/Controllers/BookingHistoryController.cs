using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XiaopengLuo_CabsBooking.Controllers
{
    public class BookingHistoryController : Controller
    {
        private readonly IBookingHistoryService _bookingHistoryService;

        public BookingHistoryController(IBookingHistoryService bookingHistoryService)
        {
            _bookingHistoryService = bookingHistoryService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _bookingHistoryService.GetAllBookingsHistory();
            return View(model);
        }

        public IActionResult AddOneBookingHistory()
        {
            return View();
        }

        public async Task<IActionResult> UpdateOneBookingHistory(int bhId)
        {
            var bookingHistory = await _bookingHistoryService.GetBookingHistoryById(bhId);
            return View(bookingHistory);
        }

        public async Task<IActionResult> GetBookingHistoryByBhid(int bhId)
        {
            var bookingHistory = await _bookingHistoryService.GetBookingHistoryById(bhId);
            return View(bookingHistory);
        }

        public IActionResult AddBookingHistory(BookingHistoryRequestDto model)
        {
            _bookingHistoryService.AddBookingHistory(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBookingHistory(int bhId)
        {
            _bookingHistoryService.DeleteBookingHistory(bhId);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateBookingHistory(BookingHistoryRequestDto model, int bhId)
        {
            model.id = bhId;
            _bookingHistoryService.UpdateBookingHistory(model);
            return RedirectToAction("Index");
        }
    }
}
