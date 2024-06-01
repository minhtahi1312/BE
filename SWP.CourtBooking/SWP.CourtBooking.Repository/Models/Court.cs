using System;
using System.Collections.Generic;

namespace SWP.CourtBooking.Repository.Models;

public partial class Court
{
    public string CourtId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public string CourtClusterId { get; set; } = null!;

    public virtual CourtCluster CourtCluster { get; set; } = null!;

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
