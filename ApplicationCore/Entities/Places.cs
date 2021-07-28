using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class Places
    {
        [Key]
        public int PlaceId { get; set; }
        [MaxLength(30)]
        public string PlaceName { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
        public ICollection<BookingsHistory> BookingsHistory { get; set; }
    }
}
