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
    public class SQLAddressRepository
    {
        private readonly MyDbContext dbContext;

        public SQLAddressRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // CREATE 
        public async Task<Address> CreateAsync(Address address)
        {
            await dbContext.Address.AddAsync(address);
            await dbContext.SaveChangesAsync();
            return address;
        }

        public async Task<Address?> DeleteAsync(int id)
        {
            var existingAddress = await dbContext.Address.FirstOrDefaultAsync(x => x.AddressId == id);
            
            if (existingAddress == null)
            {
                return null;
            }

            dbContext.Address.Remove(existingAddress);
            await dbContext.SaveChangesAsync();
            return existingAddress;
        }

        public async Task<List<Address>> GetAllAsync()
        {
            return await dbContext.Address.ToListAsync();
        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            return await dbContext.Address.FirstOrDefaultAsync(x => x.AddressId == id);
        }

        public async Task<Address?> UpdateAsync(int id, Address address)
        {
            var existingAddress = await dbContext.Address.FirstOrDefaultAsync(x => x.AddressId == id);
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
