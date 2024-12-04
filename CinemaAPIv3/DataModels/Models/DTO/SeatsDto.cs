using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.DTO
{
    public class SeatsDto
    {
        public int SeatID { get; set; }
        public int TheaterID { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
    }
}
