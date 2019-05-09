using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users_Api.Models;

namespace Users_Api.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
    }
}
