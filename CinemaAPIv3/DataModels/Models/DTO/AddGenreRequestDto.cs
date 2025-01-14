using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.DTO
{
    public class AddGenreRequestDto
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
         public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
