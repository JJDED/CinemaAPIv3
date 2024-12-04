using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class Tickets
    {
        public int TicketId { get; set; }
        public int SeatId { get; set; }
        public DateTime PurchaseDate { get; set; }

        // Foreign keys
        public int ShowtimeId { get; set; }
        public int UserId { get; set; }
    }
}
