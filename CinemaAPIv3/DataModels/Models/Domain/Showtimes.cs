using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class Showtimes
    {
        public int ShowtimesId { get; set; }
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public DateTime ShowtimeDate { get; set; }
    }
}
