using System;
using System.Collections.Generic;

namespace SWP.CourtBooking.Repository.Models;

public partial class Transaction
{
    public string TransactionId { get; set; } = null!;

    public int TotalSlot { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public string BookingId { get; set; } = null!;

    public string WalletId { get; set; } = null!;

    public string DepositId { get; set; } = null!;

    public virtual Booking Booking { get; set; } = null!;

    public virtual Deposit Deposit { get; set; } = null!;

    public virtual Wallet Wallet { get; set; } = null!;
}
