using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users_Api.Domain.Repositories;
using Users_Api.Models;
using Users_Api.Persistence.Contexts;

namespace Users_Api.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        //Find a User Item into DB
        public async Task<User> FindByUserAndPassword(string _userName, string _password)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Username == _userName && i.Password == _password);
        }

    }
}
