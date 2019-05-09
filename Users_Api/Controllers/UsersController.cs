using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Users_Api.Services;
using Users_Api.Models;
using Users_Api.Domain.Services;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Users_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        //Jwt primary implementation
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}


        //Jwt with dependency injection implementation
        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _userService.ListAsync();
            //var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            var resources = _mapper.Map<IEnumerable<User>>(users);
            return resources;
        }
    }
}
