using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.CourtBooking.Repository.DTO.Customer
{
    public class CustomerDTO
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public DateOnly? Birthday { get; set; }
        public string? Gender { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; }
        public string Password {  get; set; }
    }
}
