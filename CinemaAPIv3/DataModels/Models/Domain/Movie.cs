using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int DurationMinutes { get; set; }
        public decimal Rating { get; set; }
        public DateOnly Release { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();

        // Foreign Key
        public int ShowtimesId { get; set; }
        public List<Showtimes> Showtimes { get; set; } = new List<Showtimes>();
    }
}
