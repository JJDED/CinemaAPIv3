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
        public async Task<PostalCodeModel> CreateAsync(PostalCodeModel postalCode)
        {
            await dbContext.PostalCodes.AddAsync(postalCode);
            await dbContext.SaveChangesAsync();
            // await dbContext.Seat.AddRangeAsync(seat);
            return postalCode;
        }

        // DELETE
        public async Task<PostalCodeModel?> DeleteAsync(int id)
        {
            var existingPostalCode = await dbContext.PostalCodes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingPostalCode == null)
            {
                return null;
            }

            dbContext.PostalCodes.Remove(existingPostalCode);
            await dbContext.SaveChangesAsync();
            return existingPostalCode;
        }

        public async Task<List<PostalCodeModel>> GetAllAsync()
        {
            return await dbContext.PostalCodes.ToListAsync();
        }

        public async Task<PostalCodeModel?> GetByIdAsync(int id)
        {
            return await dbContext.PostalCodes
                         .FirstOrDefaultAsync(x => x.Id == id);
        }

        // UPDATE 
        public async Task<PostalCodeModel?> UpdateAsync(int id, PostalCodeModel postalCode)
        {
            var existingPostalCode = await dbContext.PostalCodes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingPostalCode == null)
            {
                return null; 
            }

            existingPostalCode.Id = postalCode.Id;
            existingPostalCode.Name = postalCode.Name;

            await dbContext.SaveChangesAsync();
            return existingPostalCode;
        }

    }
}
