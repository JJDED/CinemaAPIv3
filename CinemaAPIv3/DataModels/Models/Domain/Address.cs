﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street1 { get; set; } = null!;
        public string? Street2 { get; set; }
        public int StreetNumber { get; set; }
        public string? Building { get; set; }
        public int? Floor { get; set; }
        public string? Apartment { get; set; } // Erstatning for Palles Direction

        // Navigation Properties
        public int PostalCodeId { get; set; }
        public Theater? Theater { get; set; }
    }
}
