using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface IHallRepository
    {
        Task<HallModel> CreateAsync(HallModel hall);
        Task<List<HallModel>> GetAllAsync();
        Task<HallModel?> GetByIdAsync(int id);
        Task<HallModel?> UpdateAsync(int id, HallModel hall);
        Task<HallModel?> DeleteAsync(int id);

    }
}
