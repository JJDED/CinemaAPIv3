using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class Theater
    {
        public int TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }

        // Foreign key
        public int AddressId { get; set; }

        // Navigation property
        public Address? Address { get; set; }

        // Navigation collection
        public List<Seat> Seats { get; set; } = new List<Seat>();
    }
}
