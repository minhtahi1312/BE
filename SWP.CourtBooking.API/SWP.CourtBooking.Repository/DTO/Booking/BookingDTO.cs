using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.CourtBooking.Repository.DTO.Booking
{
    public class BookingDTO
    {
        public string BookingId { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CustomerId { get; set; }
        public string CourtClusterId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
    }
}
