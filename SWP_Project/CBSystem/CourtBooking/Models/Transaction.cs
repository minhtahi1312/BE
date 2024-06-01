using System;
using System.Collections.Generic;

namespace CourtBooking.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int TotalSlot { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public int BookingId { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
