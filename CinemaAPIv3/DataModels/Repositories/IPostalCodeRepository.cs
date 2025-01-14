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
        Task<PostalCodeModel> CreateAsync(PostalCodeModel postalCode);
        Task<List<PostalCodeModel>> GetAllAsync();
        Task<PostalCodeModel?> GetByIdAsync(int id);
        Task<PostalCodeModel?> UpdateAsync(int id, PostalCodeModel postalCode);
        Task<PostalCodeModel?> DeleteAsync(int id);
    }
}
