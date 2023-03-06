
using Rental_Services.DataAccessLayer;
using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.ServiceLayer
{
    public class AuthSL : IAuthSL
    {
        private readonly IAuthDL _authDL;
        public AuthSL(IAuthDL authDL)
        {
            _authDL = authDL;
        }

        public async Task<BasicResponse> AddDriver(AddDriverRequest request)
        {
            return await _authDL.AddDriver(request);
        }

        public async Task<BasicResponse> DeleteDriver(int UserID)
        {
            return await _authDL.DeleteDriver(UserID);
        }

        public async Task<GetDriveResponse> GetDrive()
        {
            return await _authDL.GetDrive();
        }

        public async Task<GetBookingResponse> GetDriverOrdersList(string Name, int PageNumber, int RecordPerPage)
        {
            return await _authDL.GetDriverOrdersList(Name, PageNumber, RecordPerPage);
        }

        public async Task<BasicResponse> IsUserOtpVerify(IsUserOtpVerifyRequest request)
        {
            return await _authDL.IsUserOtpVerify(request);
        }

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            return await _authDL.SignIn(request);
        }

        public async Task<BasicResponse> SignUp(SignUpRequest request)
        {
            return await _authDL.SignUp(request);
        }

        public async Task<BasicResponse> UpdateDriver(UpdateDriverRequest request)
        {
            return await _authDL.UpdateDriver(request);
        }
    }
}
