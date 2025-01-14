using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface IAddressRepository
    {
        Task<AddressModel> CreateAsync(AddressModel address);
        Task<List<AddressModel>> GetAllAsync();
        Task<AddressModel?> GetByIdAsync(int id);
        Task<AddressModel?> UpdateAsync(int id, AddressModel address);
        Task<AddressModel?> DeleteAsync(int id);
    }
}
