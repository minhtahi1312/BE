using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.CourtBooking.Repository.DTO.CourtCluster
{
    public class CourtClusterDTO
    {
        public string CourtClusterId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string? Image { get; set; }
        public string UserId { get; set; }
    }
}
