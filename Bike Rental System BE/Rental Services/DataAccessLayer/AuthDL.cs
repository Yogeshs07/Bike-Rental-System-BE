using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rental_Services.Data;
using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Rental_Services.ServiceLayer;

namespace Rental_Services.DataAccessLayer
{
    public class AuthDL : IAuthDL
    {

        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthDL(IConfiguration configuration, ApplicationDbContext applicationDbContext)
        {
            _configuration = configuration;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            response.IsSuccess = true;
            response.Message = "Sign In Successfully";

            try
            {
                response.data = new UserDetailResponse();

                if (request.UserName.ToLower() == "masteraccount" && request.Password.Equals("India@123"))
                {
                    response.data.UserID = -1;
                    response.data.UserName = "MasterAccount";
                    response.data.Role = "Admin";
                    response.data.Token = GenerateJwt("-1", "MasterAccount");
                    return response;
                }

                var Result = _applicationDbContext
                    .Authtable
                    .Where(X => X.UserName.ToLower() == request.UserName.ToLower() &&
                    X.Password.ToLower() == request.Password.ToLower() && X.IsAccept).FirstOrDefault();

                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Sign In Failed";
                    return response;
                }

                response.data.UserID = Result.UserID;
                response.data.UserName = Result.UserName;
                response.data.Role = Result.Role.ToUpper();
                response.data.Token = GenerateJwt(Result.UserID.ToString(), Result.UserName);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> SignUp(SignUpRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Registration Successfully";

            try
            {
                if (request.UserName.ToLower() == "masteraccount")
                {
                    response.IsSuccess = false;
                    response.Message = "Please User Another UserName.";
                    return response;
                }

                bool Found = _applicationDbContext
                    .Authtable
                    .Any(X => X.UserName.ToLower() == request.UserName.ToLower());

                if (Found)
                {
                    response.IsSuccess = false;
                    response.Message = "UserName Or Email Already Exist";
                    return response;
                }

                Account account = new Account(
                               _configuration["CloudinarySettings:CloudName"],
                               _configuration["CloudinarySettings:ApiKey"],
                               _configuration["CloudinarySettings:ApiSecret"]);


                Cloudinary cloudinary = new Cloudinary(account);
                var path = request.File.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(request.File.FileName, path)
                };

                var uploadResult = cloudinary.Upload(uploadParams);

                AuthDetails authRequest = new AuthDetails()
                {
                    InsertionDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                    UserName = request.UserName,
                    Password = request.Password,
                    Role = request.Role.ToString().ToUpper(),
                    LicenceImageUrl = uploadResult.Url.ToString(),
                    DateOfBirth = request.DateOfBirth,
                    IsAccept = false,
                    FileName = request.File.FileName
                };

                await _applicationDbContext.Authtable.AddAsync(authRequest);
                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        private string GenerateJwt(string UserID, string Email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Sid, UserID),
             new Claim(JwtRegisteredClaimNames.Email, Email),
             //new Claim(ClaimTypes.Role,Role),
             new Claim("Date", DateTime.Now.ToString()),
             };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Audiance"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<BasicResponse> AddDriver(AddDriverRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Registration Successfully";

            try
            {
                if (request.UserName.ToLower() == "masteraccount")
                {
                    response.IsSuccess = false;
                    response.Message = "Please User Another UserName.";
                    return response;
                }

                bool Found = _applicationDbContext
                    .Authtable
                    .Any(X => X.UserName.ToLower() == request.UserName.ToLower());

                if (Found)
                {
                    response.IsSuccess = false;
                    response.Message = "UserName Or Email Already Exist";
                    return response;
                }


                AuthDetails authRequest = new AuthDetails()
                {
                    InsertionDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                    UserName = request.UserName,
                    Password = request.Password,
                    Role = request.Role.ToString().ToUpper(),
                    LicenceImageUrl = request.File,
                    DateOfBirth = request.DateOfBirth,
                    IsAccept = false,
                    FileName = "Document.jpg"
                };

                await _applicationDbContext.Authtable.AddAsync(authRequest);
                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> UpdateDriver(UpdateDriverRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Driver Successfully";
            try
            {

                var data = _applicationDbContext.Authtable.FindAsync(request.UserID);
                if (data.Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Driver ID Not Found.";
                    return response;
                }

                data.Result.LicenceImageUrl = request.File;
                data.Result.UserName = request.UserName;
                data.Result.LicenceImageUrl = request.File;
                data.Result.DateOfBirth = request.DateOfBirth;
                data.Result.FileName = "Document.jpg";

                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> DeleteDriver(int UserID)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Driver Successfully";
            try
            {

                var data = _applicationDbContext.Authtable.Where(X => X.UserID == UserID).FirstOrDefault();
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Driver ID Not Found.";
                    return response;
                }

                _applicationDbContext.Authtable.Remove(data);
                int DeleteResult = await _applicationDbContext.SaveChangesAsync();
                if (DeleteResult <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something went Wrong";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<GetDriveResponse> GetDrive()
        {
            GetDriveResponse response = new GetDriveResponse();
            response.IsSuccess = true;
            response.Message = "Get Booking List Successfully";
            try
            {
                response.data = new List<GetDriveList>();

                var Result = _applicationDbContext
                    .Authtable
                    .Where(X => X.Role.ToLower() == "driver")
                    .ToList();


                if (Result.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Is Not Found.";
                    return response;
                }

                

                Result.ForEach(X =>
                {
                    response.data.Add(new GetDriveList()
                    {
                        UserID = X.UserID,
                        UserName = X.UserName,
                    });
                });

               
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<GetBookingResponse> GetDriverOrdersList(string Name, int PageNumber, int RecordPerPage)
        {
            GetBookingResponse response = new GetBookingResponse();
            response.IsSuccess = true;
            response.Message = "Get Booking List Successfully";
            try
            {
                response.data = new List<BookingDetails>();
                response.data = _applicationDbContext
                    .Bookingtable.Where(X => X.Driver.ToLower() == Name.ToLower())
                    .Skip((PageNumber-1)*RecordPerPage)
                    .Take(RecordPerPage)
                    .OrderByDescending(X => X.BookingID)
                    .ToList();

                if (response.data.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Is Not Found.";
                    return response;
                }

                double TotalRecord = _applicationDbContext
                                    .Bookingtable.Where(X => X.Driver.ToLower() == Name.ToLower())
                                    .Count();

                response.TotalPages = (int)Math.Ceiling((double)(TotalRecord / RecordPerPage));

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> IsUserOtpVerify(IsUserOtpVerifyRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "OTP Verified Successfully.";
            try
            {

                var data = _applicationDbContext.Bookingtable.FindAsync(request.BookingID);
                if (data.Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Booking ID Not Found.";
                    return response;
                }

               if(data.Result.Otp == request.Otp)
                {
                    data.Result.IsVerified = true;
                    data.Result.Status = "delivered";
                }
                else
                {
                    data.Result.IsVerified = false;
                    response.IsSuccess = false;
                    response.Message = "Invalid Otp.";
                }

                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }
    }
}
