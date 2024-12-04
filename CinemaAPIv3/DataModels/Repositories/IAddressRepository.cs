using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public class IAddressRepository
    {
        Task<Address> CreateAsync(Address address);
        Task<List<Address>> GetAllAsync();
        Task<Address?> GetByIdAsync(int id);
        Task<Address?> UpdateAsync(int id, Address address);
        Task<Address?> DeleteAsync(int id);
    }
}
