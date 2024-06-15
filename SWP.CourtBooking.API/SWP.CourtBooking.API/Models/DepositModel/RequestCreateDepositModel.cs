namespace SWP.CourtBooking.API.Models.DepositModel
{
    public class RequestCreateDepositModel
    {
        public string CustomerId { get; set; } = null!;

        public decimal Amount { get; set; }

        public string VnpayCode { get; set; } = null!;

        public DateTime Time { get; set; }
    }
}
