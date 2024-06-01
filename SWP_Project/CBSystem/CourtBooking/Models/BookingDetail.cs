using System;
using System.Collections.Generic;

namespace CourtBooking.Models;

public partial class BookingDetail
{
    public int BookingDetailId { get; set; }

    public int BookingId { get; set; }

    public int SlotId { get; set; }

    public decimal Price { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Slot Slot { get; set; } = null!;
}
