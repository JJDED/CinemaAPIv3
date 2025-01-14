using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class ShowtimesModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public DateTime ShowtimeDate { get; set; }

        // Foreign keys
        public MovieModel Movie { get; set; } = null!;
        public List<HallModel> Halls { get; set; } = new List<HallModel>();
        public List<TicketsModel> Tickets { get; set; } = new List<TicketsModel>();

    }
}
