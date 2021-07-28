using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class CabTypes
    {
        [Key]
        public int CabTypeId { get; set; }
        [MaxLength(30)]
        public string CabTypeName { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
        public ICollection<BookingsHistory> BookingsHistory { get; set; }
    }
}
