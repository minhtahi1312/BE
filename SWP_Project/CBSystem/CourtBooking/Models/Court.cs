using System;
using System.Collections.Generic;

namespace CourtBooking.Models;

public partial class Court
{
    public string CourtId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public int CourtClusterId { get; set; }

    public virtual CourtCluster CourtCluster { get; set; } = null!;

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
