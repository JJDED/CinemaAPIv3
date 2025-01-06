using System;
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
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<User> Users { get; set; } = new List<User>();
    }
}
