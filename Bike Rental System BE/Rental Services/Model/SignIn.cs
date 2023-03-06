using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Model
{
    public class SignInRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class SignInResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public UserDetailResponse data { get; set; }
    }

    public class UserDetailResponse
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }

    public class BasicResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
