using DataModels.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface IHallRepository
    {
        Task<Hall> CreateAsync(Hall hall);
        Task<List<Hall>> GetAllAsync();
        Task<Hall?> GetByIdAsync(int id);
        Task<Hall?> UpdateAsync(int id, Hall hall);
        Task<Hall?> DeleteAsync(int id);

    }
}
