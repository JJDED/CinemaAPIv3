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
    public class SQLPostalCodeRepository : IPostalCodeRepository
    {
        private readonly MyDbContext dbContext;

        public SQLPostalCodeRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // CREATE
        public async Task<PostalCode> CreateAsync(PostalCode postalCode)
        {
            await dbContext.PostalCodes.AddAsync(postalCode);
            await dbContext.SaveChangesAsync();
            // await dbContext.Seat.AddRangeAsync(seat);
            return postalCode;
        }

        // DELETE
        public async Task<PostalCode?> DeleteAsync(int id)
        {
            var existingPostalCode = await dbContext.PostalCodes.FirstOrDefaultAsync(x => x.PostalCodeId == id);

            if (existingPostalCode == null)
            {
                return null;
            }

            dbContext.PostalCodes.Remove(existingPostalCode);
            await dbContext.SaveChangesAsync();
            return existingPostalCode;
        }

        public async Task<List<PostalCode>> GetAllAsync()
        {
            return await dbContext.PostalCodes.ToListAsync();
        }

        public async Task<PostalCode?> GetByIdAsync(int id)
        {
            return await dbContext.PostalCodes
                         .FirstOrDefaultAsync(x => x.PostalCodeId == id);
        }

        // UPDATE 
        public async Task<PostalCode?> UpdateAsync(int id, PostalCode postalCode)
        {
            var existingPostalCode = await dbContext.PostalCodes.FirstOrDefaultAsync(x => x.PostalCodeId == id);

            if (existingPostalCode == null)
            {
                return null; 
            }

            existingPostalCode.PostalCodeId = postalCode.PostalCodeId;
            existingPostalCode.Name = postalCode.Name;

            await dbContext.SaveChangesAsync();
            return existingPostalCode;
        }

    }
}
