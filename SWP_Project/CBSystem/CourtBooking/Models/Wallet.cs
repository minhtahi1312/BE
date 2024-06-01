using System;
using System.Collections.Generic;

namespace CourtBooking.Models;

public partial class Wallet
{
    public int WalletId { get; set; }

    public string UserId { get; set; } = null!;

    public decimal Amount { get; set; }

    public virtual User User { get; set; } = null!;
}
