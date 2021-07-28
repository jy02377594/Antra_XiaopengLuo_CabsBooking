using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class BookingHistoryModel
    {
        public int id { get; set; }
        public string Email { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingTime { get; set; }
        public string FromPlaceName { get; set; }
        public string ToPlaceName { get; set; }
        public string PickupAddress { get; set; }
        public string Landmark { get; set; }
        public DateTime PickupDate { get; set; }
        public string PickupTime { get; set; }
        public string CabName { get; set; }
        public string ContactNo { get; set; }
        public string Status { get; set; }
        public string Comp_time { get; set; }
        public decimal Charge { get; set; }
        public string Feedback { get; set; }
    }
}
