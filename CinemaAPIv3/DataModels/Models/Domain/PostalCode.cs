﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class PostalCode
    {
        public int PostalCodeId {  get; set; }
        public string Name { get; set; }

        // Foreign key
        public int AddressId { get; set; }
        public int UserId { get; set; }
    }
}
