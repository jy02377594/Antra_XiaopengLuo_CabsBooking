using ApplicationCore;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Services
{
    public class BookingHistoryService : IBookingHistoryService
    {
        private readonly IBookingHistoryRepository _bookingHistoryRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly ICabRepository _cabRepository;

        public BookingHistoryService(IBookingHistoryRepository bookingHistoryRepository, IPlaceRepository placeRepository, ICabRepository cabRepository)
        {
            _bookingHistoryRepository = bookingHistoryRepository;
            _placeRepository = placeRepository;
            _cabRepository = cabRepository;
        }
        public void AddBookingHistory(BookingHistoryRequestDto booking)
        {
            var entity = new BookingsHistory()
            {
                id = booking.id,
                Email = booking.Email,
                BookingDate = booking.BookingDate,
                BookingTime = booking.BookingTime,
                PickupAddress = booking.PickupAddress,
                CabTypeId = booking.CabTypeId,
                ContactNo = booking.ContactNo,
                FromPlace = booking.FromPlace,
                ToPlace = booking.ToPlace,
                Landmark = booking.Landmark,
                PickupDate = booking.PickupDate,
                PickupTime = booking.PickupTime,
                Status = booking.Status,
                Charge = booking.Charge,
                Comp_time = booking.Comp_time,
                Feedback = booking.Feedback
            };

            _bookingHistoryRepository.AddBookingHistory(entity);
        }

        public void DeleteBookingHistory(int bhId)
        {
            _bookingHistoryRepository.DeleteBookingHistory(bhId);
        }

        public async Task<IEnumerable<BookingHistoryModel>> GetAllBookingsHistory()
        {
            var entities = await _bookingHistoryRepository.GetAllBookingsHistory();
            var models = new List<BookingHistoryModel>();
            foreach (var entity in entities)
            {
                var fromPlace = entity.FromPlace == 0 ? null : await _placeRepository.GetPlaceById(entity.FromPlace);
                var toPlace = entity.ToPlace == 0 ? null : await _placeRepository.GetPlaceById(entity.ToPlace);
                var cab = entity.CabTypeId == 0 ? null : await _cabRepository.GetCabById(entity.CabTypeId);
                models.Add(new BookingHistoryModel {
                    id = entity.id,
                    Email = entity.Email,
                    PickupAddress = entity.PickupAddress,
                    PickupDate = entity.PickupDate,
                    PickupTime = entity.PickupTime,
                    BookingDate = entity.BookingDate,
                    BookingTime = entity.BookingTime,
                    FromPlaceName = fromPlace == null ? null : fromPlace.PlaceName,
                    ToPlaceName = toPlace == null ? null : toPlace.PlaceName,
                    CabName = cab == null ? null : cab.CabTypeName,
                    ContactNo = entity.ContactNo,
                    Landmark = entity.Landmark,
                    Status = entity.Status,
                    Charge = entity.Charge,
                    Comp_time = entity.Comp_time,
                    Feedback = entity.Feedback
                });
            }

            return models;
        }

        public async Task<BookingHistoryRequestDto> GetBookingHistoryById(int bhId)
        {
            var entity = await _bookingHistoryRepository.GetBookingHistoryById(bhId);
            return new BookingHistoryRequestDto {
                id = entity.id,
                Email = entity.Email,
                PickupAddress = entity.PickupAddress,
                PickupDate = entity.PickupDate,
                PickupTime = entity.PickupTime,
                BookingDate = entity.BookingDate,
                BookingTime = entity.BookingTime,
                FromPlace = entity.FromPlace,
                ToPlace = entity.ToPlace,
                CabTypeId = entity.CabTypeId,
                ContactNo = entity.ContactNo,
                Landmark = entity.Landmark,
                Status = entity.Status,
                Charge = entity.Charge,
                Comp_time = entity.Comp_time,
                Feedback = entity.Feedback
            };
        }

        public void UpdateBookingHistory(BookingHistoryRequestDto booking)
        {
            var entity = new BookingsHistory() {
                id = booking.id,
                Email = booking.Email,
                BookingDate = booking.BookingDate,
                BookingTime = booking.BookingTime,
                PickupAddress = booking.PickupAddress,
                CabTypeId = booking.CabTypeId,
                ContactNo = booking.ContactNo,
                FromPlace = booking.FromPlace,
                ToPlace = booking.ToPlace,
                Landmark = booking.Landmark,
                PickupDate = booking.PickupDate,
                PickupTime = booking.PickupTime,
                Status = booking.Status,
                Charge = booking.Charge,
                Comp_time = booking.Comp_time,
                Feedback = booking.Feedback
            };

            _bookingHistoryRepository.UpdateBookingHistory(entity);
        }
    }
}
