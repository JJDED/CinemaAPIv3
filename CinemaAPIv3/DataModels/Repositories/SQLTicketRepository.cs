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
    public class SQLTicketRepository : ITicketRepository
    {
        private readonly MyDbContext dbContext;

        public SQLTicketRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // CREATE
        public async Task<TicketsModel> CreateAsync (TicketsModel tickets)
        {
            await dbContext.Tickets.AddAsync(tickets);
            await dbContext.SaveChangesAsync();
            return tickets;
        }

        // DELETE
        public async Task<TicketsModel?> DeleteAsync(int id)
        {
            var existingTicket = await dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTicket == null)
            {
                return null;
            }

            dbContext.Tickets.Remove(existingTicket);
            await dbContext.SaveChangesAsync();
            return existingTicket;
        }

        // GET ALL
        public async Task<List<TicketsModel>> GetAllAsync()
        {
            return await dbContext.Tickets.ToListAsync();
        }

        // GET BY ID
        public async Task<TicketsModel?> GetByIdAsync(int id)
        {
            return await dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        }

        // UPDATE
        public async Task<TicketsModel?> UpdateAsync(int id, TicketsModel tickets)
        {
            var existingTicket = await dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingTicket == null)
            {
                return null;
            }

            existingTicket.Id = tickets.Id;
            existingTicket.SeatId = tickets.SeatId;
            existingTicket.PurchaseDate = tickets.PurchaseDate;

            await dbContext.SaveChangesAsync();
            return existingTicket;
        }
    }
}
