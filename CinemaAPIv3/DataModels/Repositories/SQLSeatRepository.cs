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
    public class SQLSeatRepository : ISeatRepository
    {
        private readonly MyDbContext dbContext;

        public SQLSeatRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // CREATE
        public async Task<SeatModel> CreateAsync(SeatModel seat)
        {
            await dbContext.Seat.AddAsync(seat);
            await dbContext.SaveChangesAsync();
            // await dbContext.Seat.AddRangeAsync(seat);
            return seat;
        }

        // CREATE MULTIPLE SEATS
        public async Task<List<SeatModel>> CreateAsync(List<SeatModel> seat)
        {
            await dbContext.Seat.AddRangeAsync(seat);
            await dbContext.SaveChangesAsync();
            return seat;
        }

        // DELETE
        public async Task<SeatModel?> DeleteAsync(int id)
        {
            var existingSeat = await dbContext.Seat.FirstOrDefaultAsync(x => x.Id == id);

            if (existingSeat == null)
            {
                return null;
            }

            dbContext.Seat.Remove(existingSeat);
            await dbContext.SaveChangesAsync();
            return existingSeat;
        }

        // GET ALL
        public async Task<List<SeatModel>> GetAllAsync()
        {
            return await dbContext.Seat.ToListAsync();
        }

        // GET BY ID
        public async Task<SeatModel?> GetByIdAsync(int id)
        {
            return await dbContext.Seat.FirstOrDefaultAsync(x => x.Id == id);
        }

        // UPDATE 
        public async Task<SeatModel?> UpdateAsync(int id, SeatModel seat)
        {
            var existingSeat = await dbContext.Seat.FirstOrDefaultAsync(x => x.Id == id);

            if (existingSeat == null)
            {
                return null;
            }

            existingSeat.Id = seat.Id;
            existingSeat.RowNumber = seat.RowNumber;
            existingSeat.SeatNumber = seat.SeatNumber;
            //existingSeat.TheaterId = seat.TheaterId;
            //existingSeat.HallId = seat.HallId; -- Skal udtrække data fra en liste

            await dbContext.SaveChangesAsync();
            return existingSeat;
        }
    }
}
