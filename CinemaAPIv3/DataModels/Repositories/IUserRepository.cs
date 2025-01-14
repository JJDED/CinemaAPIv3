using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> CreateAsync(UserModel user);
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel?> GetByIdAsync(int id);
        Task<UserModel?> UpdateAsync(int id, UserModel user);
        Task<UserModel?> DeleteAsync(int id);
    }
}
