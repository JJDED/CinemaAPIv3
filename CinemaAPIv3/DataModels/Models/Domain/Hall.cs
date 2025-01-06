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
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public int TheaterId { get; set; }

        // Navigation property
        public Theater Theater { get; set; } = null!;
    }
}
