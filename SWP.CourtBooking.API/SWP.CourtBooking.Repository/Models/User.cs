using System;
using System.Collections.Generic;

namespace SWP.CourtBooking.Repository.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    public DateOnly? Birthday { get; set; }

    public bool? Gender { get; set; }

    public bool IsActive { get; set; }

    public string Role { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<CourtCluster> CourtClusters { get; set; } = new List<CourtCluster>();
}
