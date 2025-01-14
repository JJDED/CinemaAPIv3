using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class TicketsModel
    {
        public int Id { get; set; }
        public int SeatId { get; set; }
        public DateTime PurchaseDate { get; set; }

        // Foreign keys
        public List<UserModel> Users { get; set; } = new List<UserModel>();

        // Navigation properties
        public SeatModel Seat { get; set; } = null!;
        public ShowtimesModel showtimes { get; set; } = null!;
    }
}
