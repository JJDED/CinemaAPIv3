using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class Seat
    {
        public int SeatID { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }

        // Foreign key
        public int TheaterID { get; set; }

        // Navigation property
        public Theater Theater { get; set; } = null!;
    }
}
