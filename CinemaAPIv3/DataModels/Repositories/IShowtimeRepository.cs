using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface IShowtimeRepository
    {
        Task<Showtimes> CreateAsync(Showtimes showtime);
        Task <List<Showtimes>> GetAllAsync();
        Task<Showtimes?> GetByIdAsync(int id);
        Task<Showtimes?> UpdateAsync(int id, Showtimes showtime);
        Task<Showtimes?> DeleteAsync(int id);
    }
}
