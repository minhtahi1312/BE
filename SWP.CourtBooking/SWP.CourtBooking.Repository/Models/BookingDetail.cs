using System;
using System.Collections.Generic;

namespace SWP.CourtBooking.Repository.Models;

public partial class BookingDetail
{
    public string BookingDetailId { get; set; } = null!;

    public string BookingId { get; set; } = null!;

    public int SlotId { get; set; }

    public decimal Price { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Slot Slot { get; set; } = null!;
}
