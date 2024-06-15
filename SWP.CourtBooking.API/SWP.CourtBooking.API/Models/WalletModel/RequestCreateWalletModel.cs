namespace SWP.CourtBooking.API.Models.WalletModel
{
    public class RequestCreateWalletModel
    {
        public string CustomerId { get; set; } = null!;

        public decimal Amount { get; set; }
    }
}
