using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.DTO
{
    public class HallDto
    {
        public int HallId { get; set; }
        public int SeatColumn { get; set; }
        public int SeatRow { get; set; }

        // Foreign key
        public List<Seat> Seats = new List<Seat>();
    }
}
