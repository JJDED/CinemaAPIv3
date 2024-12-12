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
    public class SQLShowtimeRepository : IShowtimeRepository
    {
        private readonly MyDbContext dbContext;

        public SQLShowtimeRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // CREATE
        public async Task<Showtimes> CreateAsync(Showtimes showtimes)
        {
            await dbContext.Showtimes.AddAsync(showtimes);
            await dbContext.SaveChangesAsync();
            return showtimes;
        }

        // DELETE
        public async Task<Showtimes?> DeleteAsync(int id)
        {
            var existingShowtime = await dbContext.Showtimes.FirstOrDefaultAsync(x => x.ShowtimesId == id);
            
            if (existingShowtime == null)
            {
                return null;
            }

            dbContext.Showtimes.Remove(existingShowtime);
            await dbContext.SaveChangesAsync();
            return existingShowtime;
        }

        // GET ALL
        public async Task<List<Showtimes>> GetAllAsync()
        {
            return await dbContext.Showtimes.ToListAsync();
        }

        // GET BY ID
        public async Task<Showtimes?> GetByIdAsync(int id)
        {
            return await dbContext.Showtimes.FirstOrDefaultAsync(x => x.ShowtimesId == id);
        }

        // UPDATE
        public async Task<Showtimes?> UpdateAsync (int id, Showtimes showtimes)
        {
            var existingShowtime = await dbContext.Showtimes.FirstOrDefaultAsync(x => x.ShowtimesId == id);

            if (existingShowtime == null)
            {
                return null;
            }

            existingShowtime.ShowtimesId = showtimes.ShowtimesId;
            existingShowtime.MovieId = showtimes.MovieId;
            existingShowtime.TheaterId = showtimes.TheaterId;
            existingShowtime.ShowtimeDate = showtimes.ShowtimeDate;

            await dbContext.SaveChangesAsync();
            return existingShowtime;
        }
    }
}
