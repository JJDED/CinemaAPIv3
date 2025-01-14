using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Domain
{
    public class PostalCodeModel
    {
        public int Id {  get; set; }
        public string Name { get; set; }

        // Foreign key
        public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();
        public List<UserModel> Users { get; set; } = new List<UserModel>();
    }
}
