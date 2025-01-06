using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressName { get; set; } = null!;

        // Navigation Properties
        public int PostalCodeId { get; set; }
        public Theater? Theater { get; set; }
    }
}
