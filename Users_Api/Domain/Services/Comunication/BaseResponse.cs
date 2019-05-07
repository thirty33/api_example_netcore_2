using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users_Api.Domain.Services.Comunication
{
    // Class to manage object 
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
