using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.DTO
{
    public class AddAddressRequestDto
    {
        public int AddressId { get; set; }
        public string Street1 { get; set; }
        public string? Street2 { get; set; }
        public int StreetNumber { get; set; }
        public string? Building { get; set; }
        public int? Floor { get; set; }
        public string? Apartment { get; set; } // I stedet for Palles direction

        // Navigation Properties
        public int PostalCodeId { get; set; }
    }
}
