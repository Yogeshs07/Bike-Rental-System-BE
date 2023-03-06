
using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.ServiceLayer
{
    public interface IAuthSL
    {
        public Task<SignInResponse> SignIn(SignInRequest request);
        public Task<BasicResponse> SignUp(SignUpRequest request);
        public Task<BasicResponse> AddDriver(AddDriverRequest request);
        public Task<BasicResponse> UpdateDriver(UpdateDriverRequest request);
        public Task<BasicResponse> DeleteDriver(int UserID);
        public Task<GetDriveResponse> GetDrive();
        public Task<GetBookingResponse> GetDriverOrdersList(string Name, int PageNumber, int RecordPerPage);
        public Task<BasicResponse> IsUserOtpVerify(IsUserOtpVerifyRequest request);
    }
}
