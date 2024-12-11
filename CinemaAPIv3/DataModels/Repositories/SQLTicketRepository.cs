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
        public async Task<Tickets> CreateAsync (Tickets tickets)
        {
            await dbContext.Tickets.AddAsync(tickets);
            await dbContext.SaveChangesAsync();
            return tickets;
        }

        // DELETE
        public async Task<Tickets?> DeleteAsync(int id)
        {
            var existingTicket = await dbContext.Tickets.FirstOrDefaultAsync(x => x.TicketId == id);

            if (existingTicket == null)
            {
                return null;
            }

            dbContext.Tickets.Remove(existingTicket);
            await dbContext.SaveChangesAsync();
            return existingTicket;
        }

        // GET ALL
        public async Task<List<Tickets>> GetAllAsync()
        {
            return await dbContext.Tickets.ToListAsync();
        }

        // GET BY ID
        public async Task<Tickets?> GetByIdAsync(int id)
        {
            return await dbContext.Tickets.FirstOrDefaultAsync(x => x.TicketId == id);
        }

        // UPDATE
        public async Task<Tickets?> UpdateAsync(int id, Tickets tickets)
        {
            var existingTicket = await dbContext.Tickets.FirstOrDefaultAsync(x => x.TicketId == id);
            
            if (existingTicket == null)
            {
                return null;
            }

            existingTicket.TicketId = tickets.TicketId;
            existingTicket.SeatId = tickets.SeatId;
            existingTicket.PurchaseDate = tickets.PurchaseDate;
            existingTicket.ShowtimeId = tickets.ShowtimeId;

            await dbContext.SaveChangesAsync();
            return existingTicket;
        }
    }
}
