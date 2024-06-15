using SWP.CourtBooking.Repository.Models;

namespace SWP.CourtBooking.API.Models.BookingDetailModel
{
    public class RequestCreateBookingDetailModel
    {
        public string BookingId { get; set; } = null!;

        public int SlotId { get; set; }

        public decimal Price { get; set; }

        public virtual Booking Booking { get; set; } = null!;

        public virtual Slot Slot { get; set; } = null!;
    }
}
