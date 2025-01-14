using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface ITicketRepository
    {
        Task<TicketsModel> CreateAsync(TicketsModel tickets);
        Task<List<TicketsModel>> GetAllAsync();
        Task <TicketsModel?> GetByIdAsync(int id);
        Task <TicketsModel?> UpdateAsync(int id, TicketsModel tickets);
        Task<TicketsModel?> DeleteAsync(int id);

    }
}
