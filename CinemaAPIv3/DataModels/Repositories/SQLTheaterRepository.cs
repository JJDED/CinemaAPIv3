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
    public class SQLTheaterRepository : ITheaterRepository
    {
        private readonly MyDbContext dbContext;

        public SQLTheaterRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET Theater - POST /api/theater
        public async Task<TheaterModel> CreateAsync(TheaterModel theater)
        {
            await dbContext.Theaters.AddAsync(theater);
            await dbContext.SaveChangesAsync();
            return theater;
        }

        // GET All Theaters - GET /api/theater
        public async Task<List<TheaterModel>> GetAllAsync()
        {
            return await dbContext.Theaters.ToListAsync();
        }

        // GET Theater by Id - GET /api/theater/{id}
        public async Task<TheaterModel?> GetByIdAsync(int id)
        {
            return await dbContext.Theaters
                         .FirstOrDefaultAsync(x => x.Id == id);


        }

        // UPDATE Theater by Id - PUT /api/theater/{id}
        public async Task<TheaterModel?> UpdateAsync(int id, TheaterModel theater)
        {
            var existingTheater = await dbContext.Theaters.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTheater == null)
            {
                return null;
            }

            existingTheater.TheaterName = theater.TheaterName;
            existingTheater.Location = theater.Location;
            existingTheater.Capacity = theater.Capacity;
            existingTheater.AddressId = theater.AddressId;
            existingTheater.Address = theater.Address;

            await dbContext.SaveChangesAsync();
            return existingTheater;
        }

        // DELETE Theater - DELETE /api/theater{id}
        public async Task<TheaterModel?> DeleteAsync(int id)
        {
            var existingTheater = await dbContext.Theaters.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTheater == null)
            {
                return null;
            }

            dbContext.Theaters.Remove(existingTheater); // There is no Async remove in EF at this time.
            await dbContext.SaveChangesAsync();
            return existingTheater;
        }
    }    
}
