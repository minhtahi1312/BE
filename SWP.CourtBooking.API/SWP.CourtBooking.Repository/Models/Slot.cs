using System;
using System.Collections.Generic;

namespace SWP.CourtBooking.Repository.Models;

public partial class Slot
{
    public int SlotId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string CourtId { get; set; } = null!;

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual Court Court { get; set; } = null!;
}
