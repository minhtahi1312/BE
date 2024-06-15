namespace SWP.CourtBooking.API.Models.BookingModel
{
    public class RequestCreateBookingModel
    {
        public string Code { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public string CustomerId { get; set; } = null!;

        public string CourtClusterId { get; set; } = null!;

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }
    }
}
