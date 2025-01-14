using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface ISeatRepository
    {
        Task<SeatModel> CreateAsync(SeatModel seat);
        Task<List<SeatModel>> CreateAsync(List<SeatModel> seat);
        Task<List<SeatModel>> GetAllAsync();
        Task<SeatModel?> GetByIdAsync(int id);
        Task<SeatModel?> UpdateAsync(int id, SeatModel seat);
        Task<SeatModel?> DeleteAsync(int id);
    }
}
