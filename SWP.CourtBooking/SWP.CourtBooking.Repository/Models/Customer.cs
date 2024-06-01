using System;
using System.Collections.Generic;

namespace SWP.CourtBooking.Repository.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Gender { get; set; }

    public bool IsActive { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();

    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}
