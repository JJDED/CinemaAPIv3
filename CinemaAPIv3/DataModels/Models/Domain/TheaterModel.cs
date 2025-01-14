using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class TheaterModel
    {
        public int Id { get; set; }
        public string TheaterName { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }

        // Foreign key
        public int AddressId { get; set; }

        // Navigation property
        public AddressModel? Address { get; set; }
        public List<HallModel> Halls { get; set; } = new List<HallModel>();

    }
}
