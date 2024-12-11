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
        Task<Tickets> CreateAsync(Tickets tickets);
        Task<List<Tickets>> GetAllAsync();
        Task <Tickets?> GetByIdAsync(int id);
        Task <Tickets?> UpdateAsync(int id, Tickets tickets);
        Task<Tickets?> DeleteAsync(int id);

    }
}
