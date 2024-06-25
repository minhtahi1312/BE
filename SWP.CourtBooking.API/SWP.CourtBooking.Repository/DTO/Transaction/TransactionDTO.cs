using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.CourtBooking.Repository.DTO.Transaction
{
    public class TransactionDTO
    {
        public string TransactionId { get; set; }
        public int TotalSlot { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string BookingId { get; set; }
        public string WalletId { get; set; }
        public string DepositId { get; set; }
    }
}
