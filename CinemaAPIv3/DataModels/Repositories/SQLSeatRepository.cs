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
        public async Task<Seat> CreateAsync(Seat seat)
        {
            await dbContext.Seat.AddAsync(seat);
            await dbContext.SaveChangesAsync();
            return seat;
        }

        // DELETE
        public async Task<Seat?> DeleteAsync(int id)
        {
            var existingSeat = await dbContext.Seat.FirstOrDefaultAsync(x => x.SeatId == id);

            if (existingSeat == null)
            {
                return null;
            }

            dbContext.Seat.Remove(existingSeat);
            await dbContext.SaveChangesAsync();
            return existingSeat;
        }

        // GET ALL
        public async Task<List<Seat>> GetAllAsync()
        {
            return await dbContext.Seat.ToListAsync();
        }

        // GET BY ID
        public async Task<Seat?> GetByIdAsync(int id)
        {
            return await dbContext.Seat.FirstOrDefaultAsync(x => x.SeatId == id);
        }

        // UPDATE 
        public async Task<Seat?> UpdateAsync(int id, Seat seat)
        {
            var existingSeat = await dbContext.Seat.FirstOrDefaultAsync(x => x.SeatId == id);

            if (existingSeat == null)
            {
                return null;
            }

            existingSeat.SeatId = seat.SeatId;
            existingSeat.RowNumber = seat.RowNumber;
            existingSeat.SeatNumber = seat.SeatNumber;
            //existingSeat.TheaterId = seat.TheaterId;
            //existingSeat.HallId = seat.HallId; -- Skal udtrække data fra en liste

            await dbContext.SaveChangesAsync();
            return existingSeat;
        }
    }
}
