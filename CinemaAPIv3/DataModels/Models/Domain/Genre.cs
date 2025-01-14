﻿using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
        
    }
}
