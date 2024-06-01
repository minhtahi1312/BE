using System;
using System.Collections.Generic;

namespace CourtBooking.Models;

public partial class Deposit
{
    public int DepositId { get; set; }

    public string UserId { get; set; } = null!;

    public decimal Amount { get; set; }

    public string VnpayCode { get; set; } = null!;

    public DateTime? Time { get; set; }

    public virtual User User { get; set; } = null!;
}
