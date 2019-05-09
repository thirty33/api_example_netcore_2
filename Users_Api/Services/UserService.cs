using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Users_Api.Domain.Repositories;
using Users_Api.Domain.Services;
using Users_Api.Helpers;
using Users_Api.Models;

namespace Users_Api.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Joel", LastName = "Suarez", Username = "joel", Password = "admin" },
            new User { Id = 2, FirstName = "Carlos", LastName = "Torrealba", Username = "carl", Password = "admin" },
        };

        //Dependency Injection Implementation
        private readonly IUserRepository _userRepository;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            //User not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        //Local Implementation
        //public IEnumerable<User> GetAll()
        //{
        //    // return users without passwords
        //    return _users.Select(x =>
        //    {
        //        x.Password = null;
        //        return x;
        //    });
        //}

        //Dependency injection Implementation
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
    }
    }
