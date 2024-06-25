using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.CourtBooking.Repository.DTO.Deposit
{
    public class DepositDTO
    {
        public string DepositId { get; set; }
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string VnpayCode { get; set; }
        public DateTime Time { get; set; }
    }
}
