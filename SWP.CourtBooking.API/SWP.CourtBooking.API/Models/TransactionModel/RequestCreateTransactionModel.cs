namespace SWP.CourtBooking.API.Models.TransactionModel
{
    public class RequestCreateTransactionModel
    {
        public int TotalSlot { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = null!;

        public string BookingId { get; set; } = null!;

        public string WalletId { get; set; } = null!;

        public string DepositId { get; set; } = null!;
    }
}
