using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.DTO
{
    public class ShowtimesDto
    {
        public int ShowtimeId { get; set; }
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public DateTime Showtime { get; set; }

    }
}
