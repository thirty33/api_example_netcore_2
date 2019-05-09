using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users_Api.Domain.Services.Comunication;
using Users_Api.Models;

namespace Users_Api.Domain.Services
{
    public interface IUserService
    {
        //User Authenticate(string username, string password);

        //Dependency injection Implementation
        //Task<UserAuthenticatedResponse> Authenticate(string username, string password);
        Task<User> Authenticate(string username, string password);
        //IEnumerable<User> GetAll();

        //Jwt part2
        Task<IEnumerable<User>> ListAsync();
    }
}
