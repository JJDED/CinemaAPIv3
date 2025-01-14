﻿using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.DTO
{
    public class AddSeatRequestDto
    {
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }

        // Foreign key
        public int HallID { get; set; }

        // Navigation property
        // public Theater Theater { get; set; } = null!;
    }
}
