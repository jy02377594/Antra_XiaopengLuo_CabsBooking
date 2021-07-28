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
    public class BookingService : IBookingService
    {

        private readonly IBookingRepository _bookingRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly ICabRepository _cabRepository;

        public BookingService(IBookingRepository bookingRepository, IPlaceRepository placeRepository, ICabRepository cabRepository)
        {
            _bookingRepository = bookingRepository;
            _placeRepository = placeRepository;
            _cabRepository = cabRepository;
        }

        public void AddBooking(BookingAddRequestDto booking)
        {
            //var fromPlace = _placeRepository.GetPlaceById(booking.FromPlace);
            //var toPlace = _placeRepository.GetPlaceById(booking.ToPlace);
            //var cab = _cabRepository.GetCabById(booking.CabTypeId);
            //if (fromPlace == null) throw new Exception("There is no place to match fromPlace");
            //if (toPlace == null) throw new Exception("There is no place to match toPlace");
            //if (cab == null) throw new Exception("There is no cab to match");

            var entity = new Bookings()
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
                Status = booking.Status
            };

            _bookingRepository.AddBooking(entity);
        }

        public void DeleteBooking(int bId)
        {
            _bookingRepository.DeleteBooking(bId);
        }

        public async Task<IEnumerable<BookingModel>> GetAllBookings()
        {
            var entities = await _bookingRepository.GetAllBookings();
            var models = new List<BookingModel>();
            foreach (var entity in entities)
            {
                var fromPlace = entity.FromPlace == 0 ? null : await _placeRepository.GetPlaceById(entity.FromPlace);
                var toPlace = entity.ToPlace == 0 ? null : await _placeRepository.GetPlaceById(entity.ToPlace);
                var cab = entity.CabTypeId == 0 ? null : await _cabRepository.GetCabById(entity.CabTypeId);
                models.Add(new BookingModel {
                    id = entity.id,
                    Email = entity.Email,
                    PickupAddress = entity.PickupAddress,
                    PickupDate = entity.PickupDate,
                    PickupTime = entity.PickupTime,
                    BookingDate = entity.BookingDate,
                    BookingTime = entity.BookingTime,
                    FromPlaceName = fromPlace == null ? null : fromPlace.PlaceName,
                    ToPlaceName = toPlace == null ? null : toPlace.PlaceName,
                    CabTyeName = cab == null ? null : cab.CabTypeName,
                    ContactNo = entity.ContactNo,
                    Landmark = entity.Landmark,
                    Status = entity.Status
                });
            }

            return models;
        }

        public async Task<BookingAddRequestDto> GetBookingById(int bId)
        {
            var entity = await _bookingRepository.GetBookingById(bId);
            return new BookingAddRequestDto() {
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
                Status = entity.Status
            };
        }

        public void UpdateBooking(BookingAddRequestDto booking)
        {
            //var fromPlace = _placeRepository.GetPlaceById(booking.FromPlace);
            //var toPlace = _placeRepository.GetPlaceById(booking.ToPlace);
            //var cab = _cabRepository.GetCabById(booking.CabTypeId);
            //if (fromPlace == null) throw new Exception("There is no place to match fromPlace");
            //if (toPlace == null) throw new Exception("There is no place to match toPlace");
            //if (cab == null) throw new Exception("There is no cab to match");

            var entity = new Bookings()
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
                Status = booking.Status
            };

            _bookingRepository.UpdateBooking(entity);
        }
    }
}
