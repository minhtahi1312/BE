using System;
using System.Collections.Generic;

namespace CourtBooking.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public string Code { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string UserId { get; set; } = null!;

    public int CourtClusterId { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual CourtCluster CourtCluster { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}
