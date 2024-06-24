using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.CourtBooking.Repository.DTO.BookingDetail
{
    public class BookingDetailDTO
    {
        public string BookingDetailId { get; set; } = null!;
        public string BookingId { get; set; } = null!;
        public int SlotId { get; set; }
        public decimal Price { get; set; }
    }
}
