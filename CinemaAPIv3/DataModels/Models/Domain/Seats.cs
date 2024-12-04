using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class Seats
    {
        public int SeatID { get; set; }
        public int TheaterID { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
    }
}
