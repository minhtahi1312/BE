using System;
using System.Collections.Generic;

namespace SWP.CourtBooking.Repository.Models;

public partial class Deposit
{
    public string DepositId { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public decimal Amount { get; set; }

    public string VnpayCode { get; set; } = null!;

    public DateTime Time { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
