using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class HallModel
    {
        public int Id { get; set; }
        public int SeatColumn { get; set; }
        public int SeatRow { get; set; }

        // Foreign key
        public List<SeatModel> Seats { get; set; } = new List<SeatModel>();
        public int TheaterId { get; set; }

        // Navigation property
        public TheaterModel Theater { get; set; } = null!;
    }
}
