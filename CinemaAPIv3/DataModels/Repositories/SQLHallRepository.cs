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
    public class SQLHallRepository : IHallRepository
    {
        private readonly MyDbContext dbContext;

        public SQLHallRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // CREATE 
        public async Task<HallModel> CreateAsync(HallModel hall)
        {
            await dbContext.Hall.AddAsync(hall);
            await dbContext.SaveChangesAsync();
            return hall;
        }

        public async Task<HallModel?> DeleteAsync(int id)
        {
            var existingHall = await dbContext.Hall.FirstOrDefaultAsync(x => x.Id == id);

            if (existingHall == null)
            {
                return null;
            }

            dbContext.Hall.Remove(existingHall);
            await dbContext.SaveChangesAsync();
            return existingHall;
        }

        public async Task<List<HallModel>> GetAllAsync()
        {
            return await dbContext.Hall.ToListAsync();
        }

        public async Task<HallModel?> GetByIdAsync(int id)
        {
            return await dbContext.Hall.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<HallModel?> UpdateAsync(int id, HallModel hall)
        {
            var existingHall = await dbContext.Hall.FirstOrDefaultAsync(x => x.Id == id);
            if (existingHall == null)
            {
                return null;
            }

            existingHall.Id = hall.Id;
            existingHall.SeatColumn = hall.SeatColumn;
            existingHall.SeatRow = hall.SeatRow;
            existingHall.Seats = hall.Seats;

            await dbContext.SaveChangesAsync();
            return existingHall;


        }
    }
}
