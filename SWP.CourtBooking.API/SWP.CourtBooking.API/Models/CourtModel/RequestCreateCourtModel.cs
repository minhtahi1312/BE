using SWP.CourtBooking.Repository.Models;

namespace SWP.CourtBooking.API.Models.CourtModel
{
    public class RequestCreateCourtModel
    {
        public string Name { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string? Description { get; set; }

        public string CourtClusterId { get; set; } = null!;

    }
}
