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
        Task<ShowtimesModel> CreateAsync(ShowtimesModel showtimes);
        Task<List<ShowtimesModel>> GetAllAsync();
        Task<ShowtimesModel?> GetByIdAsync(int id);
        Task<ShowtimesModel?> UpdateAsync(int id, ShowtimesModel showtimes);
        Task<ShowtimesModel?> DeleteAsync(int id);
    }
}
