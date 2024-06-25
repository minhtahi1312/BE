using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.CourtBooking.Repository.DTO.Wallet
{
    public class WalletDTO
    {
        public string WalletId { get; set; }
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}
