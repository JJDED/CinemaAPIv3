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
        Task<Seat> CreateAsync(Seat seat);
        Task<List<Seat>> CreateAsync(List<Seat> seat);
        Task<List<Seat>> GetAllAsync();
        Task<Seat?> GetByIdAsync(int id);
        Task<Seat?> UpdateAsync(int id, Seat seat);
        Task<Seat?> DeleteAsync(int id);
    }
}
