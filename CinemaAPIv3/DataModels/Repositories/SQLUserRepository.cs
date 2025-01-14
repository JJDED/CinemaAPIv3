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
    public class SQLUserRepository : IUserRepository
    {
        private readonly MyDbContext dbContext;

        public SQLUserRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<UserModel> CreateAsync(UserModel user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel?> DeleteAsync(int id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            dbContext.Users.Remove(existingUser); // There is no Async remove in EF at this time.
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel?> UpdateAsync(int id, UserModel user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;

            await dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
