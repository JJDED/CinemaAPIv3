using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.DTO
{
    public class TheaterDto
    {
        public int TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
        public Address? Address { get; set; }
        public int AddressId { get; set; }
    }
}
