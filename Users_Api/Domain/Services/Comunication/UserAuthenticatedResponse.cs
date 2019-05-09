using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users_Api.Models;

namespace Users_Api.Domain.Services.Comunication
{
    public class UserAuthenticatedResponse : BaseResponse
    {
        public User User { get; private set; }

        //Constructor
        private UserAuthenticatedResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="user">Saved cate.</param>
        /// <returns>Response.</returns>
        public UserAuthenticatedResponse(User user) : this(true, string.Empty, user)
        { }


        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserAuthenticatedResponse(string message) : this(false, message, null)
        { }
    }
}
