using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class Hall
    {
        public int HallId { get; set; }
        public int SeatColumn { get; set; }
        public int SeatRow { get; set; }

        // Foreign key
        public int TheaterId { get; set; }
        public int SeatId { get; set; }

        public List<Seat> Seats = new List<Seat>();

        // Navigation property
        public Theater Theater { get; set; } = null!;
    }
}
