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
    public class SQLAddressRepository : IAddressRepository
    {
        private readonly MyDbContext dbContext;

        public SQLAddressRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // CREATE 
        public async Task<AddressModel> CreateAsync(AddressModel address)
        {
            await dbContext.Address.AddAsync(address);
            await dbContext.SaveChangesAsync();
            return address;
        }

        public async Task<AddressModel?> DeleteAsync(int id)
        {
            var existingAddress = await dbContext.Address.FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingAddress == null)
            {
                return null;
            }

            dbContext.Address.Remove(existingAddress);
            await dbContext.SaveChangesAsync();
            return existingAddress;
        }

        public async Task<List<AddressModel>> GetAllAsync()
        {
            return await dbContext.Address.ToListAsync();
        }

        public async Task<AddressModel?> GetByIdAsync(int id)
        {
            return await dbContext.Address.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AddressModel?> UpdateAsync(int id, AddressModel address)
        {
            var existingAddress = await dbContext.Address.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAddress == null)
            {
                return null;
            }

            existingAddress.AddressName = address.AddressName;

            await dbContext.SaveChangesAsync();
            return existingAddress;
        }
    }
}
