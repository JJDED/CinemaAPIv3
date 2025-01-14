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
        public async Task<Genre> CreateAsync(Genre genre)
        {
            await dbContext.Genres.AddAsync(genre);
            await dbContext.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre?> DeleteAsync(int id)
        {
            var existingGenre = await dbContext.Genres.FirstOrDefaultAsync(x => x.GenreId == id);

            if (existingGenre == null)
            {
                return null;
            }

            dbContext.Genres.Remove(existingGenre); // There is no Async remove in EF at this time.
            await dbContext.SaveChangesAsync();
            return existingGenre;
        }
        public async Task<List<Genre>> GetAllAsync()
        {
            return await dbContext.Genres.ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await dbContext.Genres
                         .FirstOrDefaultAsync(x => x.GenreId == id);


        }

        public async Task<Genre?> UpdateAsync(int id, Genre genre)
        {
            var existingGenre = await dbContext.Genres.FirstOrDefaultAsync(x => x.GenreId == id);
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
