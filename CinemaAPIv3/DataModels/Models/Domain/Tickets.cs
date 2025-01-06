using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class Tickets
    {
        public int TicketsId { get; set; }
        public int SeatId { get; set; }
        public DateTime PurchaseDate { get; set; }

        // Foreign keys
        public List<User> Users { get; set; } = new List<User>();

        // Navigation properties
        public Seat Seat { get; set; } = null!;
        public Showtimes showtimes { get; set; } = null!;
    }
}
