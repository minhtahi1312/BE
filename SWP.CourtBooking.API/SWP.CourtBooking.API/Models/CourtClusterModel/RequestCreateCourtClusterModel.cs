namespace SWP.CourtBooking.API.Models.CourtClusterModel
{
    public class RequestCreateCourtClusterModel
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string? Image { get; set; }

        public string UserId { get; set; } = null!;
    }
}
