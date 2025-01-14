using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface IPostalCodeRepository
    {
        Task<PostalCode> CreateAsync(PostalCode postalCode);
        Task<List<PostalCode>> GetAllAsync();
        Task<PostalCode?> GetByIdAsync(int id);
        Task<PostalCode?> UpdateAsync(int id, PostalCode postalCode);
        Task<PostalCode?> DeleteAsync(int id);
    }
}
