namespace SWP.CourtBooking.API.Models.CustomerModel
{
    public class RequestCreateCustomerModel
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string? Address { get; set; }

        public DateOnly? Birthday { get; set; }

        public string? Gender { get; set; }

        public bool IsActive { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
