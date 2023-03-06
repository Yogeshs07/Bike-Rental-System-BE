using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Model
{
    public class SignUpRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public IFormFile File { get; set; }
        public string DateOfBirth { get; set; }

    }

    public enum Roles
    {
        ADMIN, CUSTOMER, Driver
    }

    public class AddDriverRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public string File { get; set; }
        public string DateOfBirth { get; set; }
    }

    public class UpdateDriverRequest
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string File { get; set; }
        public string DateOfBirth { get; set; }
    }

    public class GetDriveResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<GetDriveList> data { get; set; }
    }

    public class GetDriveList
    {
        public int UserID { get; set; }

        public string UserName { get; set; }
    }

    public class IsUserOtpVerifyRequest
    {
        public int BookingID { get; set; }
        public string Otp { get; set; }
    }
}
