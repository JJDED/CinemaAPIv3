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
    public class SQLHallRepository
    {
        private readonly MyDbContext dbContext;

        public SQLHallRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // CREATE 
        public async Task<Hall> CreateAsync(Hall hall)
        {
            await dbContext.Hall.AddAsync(hall);
            await dbContext.SaveChangesAsync();
            return hall;
        }

        public async Task<Hall?> DeleteAsync(int id)
        {
            var existingHall = await dbContext.Hall.FirstOrDefaultAsync(x => x.HallId == id);

            if (existingHall == null)
            {
                return null;
            }

            dbContext.Hall.Remove(existingHall);
            await dbContext.SaveChangesAsync();
            return existingHall;
        }

        public async Task<List<Hall>> GetAllAsync()
        {
            return await dbContext.Hall.ToListAsync();
        }

        public async Task<Hall?> GetByIdAsync(int id)
        {
            return await dbContext.Hall.FirstOrDefaultAsync(x => x.HallId == id);
        }

        public async Task<Hall?> UpdateAsync(int id, Hall hall)
        {
            var existingHall = await dbContext.Hall.FirstOrDefaultAsync(x => x.HallId == id);
            if (existingHall == null)
            {
                return null;
            }

            existingHall.HallId = hall.HallId;
            existingHall.SeatColumn = hall.SeatColumn;
            existingHall.SeatRow = hall.SeatRow;
            existingHall.Seats = hall.Seats;

            await dbContext.SaveChangesAsync();
            return existingHall;


        }
    }
}
