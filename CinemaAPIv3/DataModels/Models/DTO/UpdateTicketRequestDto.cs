using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.DTO
{
    public class UpdateTicketRequestDto
    {
        public int TicketId { get; set; }
        public int SeatId { get; set; }
        public DateTime PurchaseDate { get; set; }

        // Foreign keys
        public int ShowtimeId { get; set; }
        public int UserId { get; set; }
    }
}
