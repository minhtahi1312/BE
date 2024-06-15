namespace SWP.CourtBooking.API.Models.UserModel
{
    public class RequestCreateUserModel
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string? Address { get; set; }

        public DateOnly? Birthday { get; set; }

        public bool? Gender { get; set; }

        public bool IsActive { get; set; }

        public string Role { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
