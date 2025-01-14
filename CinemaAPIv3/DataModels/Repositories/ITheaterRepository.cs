using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface ITheaterRepository
    {
        Task<TheaterModel> CreateAsync(TheaterModel theater);
        Task<List<TheaterModel>> GetAllAsync();
        Task<TheaterModel?> GetByIdAsync(int id);
        Task<TheaterModel?> UpdateAsync(int id, TheaterModel theater);
        Task<TheaterModel?> DeleteAsync(int id);
    }
}
