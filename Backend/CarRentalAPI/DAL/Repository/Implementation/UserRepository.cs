using DAL.Data;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly CarRentalDbContext dbContext;

        public UserRepository(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user=await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}
