using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface IMovieRepository
    {
        Task<MovieModel> CreateAsync(MovieModel movie);
        Task<List<MovieModel>> GetAllAsync();
        Task<MovieModel?> GetByIdAsync(int id);
        Task<MovieModel?> UpdateAsync(int id, MovieModel movie);
        Task<MovieModel?> DeleteAsync(int id);
    }
}
