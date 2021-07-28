using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class BookingAddRequestDto
    {
        public int id { get; set; }
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime BookingDate { get; set; }
        [MaxLength(5)]
        public string BookingTime { get; set; }
        public int FromPlace { get; set; }
        public int ToPlace { get; set; }
        [MaxLength(200)]
        public string PickupAddress { get; set; }
        [MaxLength(30)]
        public string Landmark { get; set; }
        public DateTime PickupDate { get; set; }
        [MaxLength(5)]
        public string PickupTime { get; set; }
        public int CabTypeId { get; set; }
        [MaxLength(25)]
        public string ContactNo { get; set; }
        [MaxLength(30)]
        public string Status { get; set; }
    }
}
