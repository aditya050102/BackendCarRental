using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User>GetUserByEmailAsync(string email);
    }
}
