using DataModels.Data;
using DataModels.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public class SQLGenreRepository : IGenreRepository
    {
        private readonly MyDbContext dbContext;

        public SQLGenreRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<GenreModel> CreateAsync(GenreModel genre)
        {
            await dbContext.Genres.AddAsync(genre);
            await dbContext.SaveChangesAsync();
            return genre;
        }

        public async Task<GenreModel?> DeleteAsync(int id)
        {
            var existingGenre = await dbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (existingGenre == null)
            {
                return null;
            }

            dbContext.Genres.Remove(existingGenre); // There is no Async remove in EF at this time.
            await dbContext.SaveChangesAsync();
            return existingGenre;
        }
        public async Task<List<GenreModel>> GetAllAsync()
        {
            return await dbContext.Genres.ToListAsync();
        }

        public async Task<GenreModel?> GetByIdAsync(int id)
        {
            return await dbContext.Genres
                         .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<GenreModel?> UpdateAsync(int id, GenreModel genre)
        {
            var existingGenre = await dbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (existingGenre == null)
            {
                return null;
            }

            existingGenre.GenreName = genre.GenreName;

            await dbContext.SaveChangesAsync();
            return existingGenre;
        }
    }
}
