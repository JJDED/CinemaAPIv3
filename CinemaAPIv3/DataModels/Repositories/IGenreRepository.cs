using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface IGenreRepository
    {
        Task<GenreModel> CreateAsync(GenreModel genre);
        Task<List<GenreModel>> GetAllAsync();
        Task<GenreModel?> GetByIdAsync(int id);
        Task<GenreModel?> UpdateAsync(int id, GenreModel genre);
        Task<GenreModel?> DeleteAsync(int id);
    }
}
