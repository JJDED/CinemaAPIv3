using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.DTO
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string AddressName { get; set; } = null!;

        // Navigation property
        public PostalCode PostalCode { get; set; }
        public int PostalCodeId { get; set; }
    }
}
