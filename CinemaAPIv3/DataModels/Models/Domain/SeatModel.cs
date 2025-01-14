using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class SeatModel
    {
        public int Id { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }

        // Navigation property
        public List<HallModel> Halls { get; set; } = new List<HallModel>();
    }
}
