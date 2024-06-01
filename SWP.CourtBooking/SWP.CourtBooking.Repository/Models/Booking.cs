using System;
using System.Collections.Generic;

namespace SWP.CourtBooking.Repository.Models;

public partial class Booking
{
    public string BookingId { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CustomerId { get; set; } = null!;

    public string CourtClusterId { get; set; } = null!;

    public DateTime FromTime { get; set; }

    public DateTime ToTime { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual CourtCluster CourtCluster { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
