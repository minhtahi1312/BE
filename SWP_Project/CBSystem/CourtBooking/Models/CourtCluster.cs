using System;
using System.Collections.Generic;

namespace CourtBooking.Models;

public partial class CourtCluster
{
    public int CourtClusterId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public string? Location { get; set; }

    public string? Image { get; set; }

    public string UserId { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Court> Courts { get; set; } = new List<Court>();

    public virtual User User { get; set; } = null!;
}
