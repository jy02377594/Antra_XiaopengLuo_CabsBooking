using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class Bookings
    {
        [Key]
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

        public Places Places { get; set; }
        public CabTypes CabTypes { get; set; }
    }
}
