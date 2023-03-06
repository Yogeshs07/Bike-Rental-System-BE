using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Rental_Services.Data;
using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Services.DataAccessLayer
{
    public class UserDL : IUserDL
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _applicationDbContext;

        public UserDL(IConfiguration configuration, ApplicationDbContext applicationDbContext)
        {
            _configuration = configuration;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BasicResponse> AddBooking(AddBookingRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Add Booking Successfully";
            try
            {


                BookingDetails data = new BookingDetails()
                {
                    InsertionDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                    UserID = request.UserID,
                    UserName = request.UserName,
                    MobileNumber = request.MobileNumber,
                    BookingDate = request.BookingDate.Replace('T', ' '),
                    Hub = request.Hub,
                    EmailID = request.EmailID,
                    TotalPrice = request.TotalPrice,
                    TotalDistance = request.TotalDistance,
                    Status = request.Status,
                    VehicleID = request.VehicleID,
                    VehicleName = request.VehicleName,
                    VehicleNumber = request.VehicleNumber,
                    VehicleDescription = request.VehicleDescription,
                    BikeCompany = request.BikeCompany,
                    PricePerKm = request.PricePerKm,
                    ImageUrl = request.ImageUrl
                };

                await _applicationDbContext.Bookingtable.AddAsync(data);
                int Result = await _applicationDbContext.SaveChangesAsync();
                if (Result <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> AddProfileDetails(AddProfileDetailsRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Add Profile Details Successfully";
            try
            {


                ProfileDetails data = new ProfileDetails();
                data.UserID = request.UserID;
                data.Address = request.Address;
                data.MobileNumber = request.MobileNumber;
                data.EmailID = request.EmailID;
                data.Pincode = request.Pincode;

                await _applicationDbContext.ProfileDetailstables.AddAsync(data);
                int Result = await _applicationDbContext.SaveChangesAsync();
                if (Result <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> DeleteBooking(int BookingID)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Cancel Booking Successfully";
            try
            {
                var Result = _applicationDbContext
                    .Bookingtable
                    .Where(X => X.BookingID == BookingID).FirstOrDefault();

                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Is Not Found.";
                    return response;
                }

                Result.Status = "cancel";

                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<GetBookingResponse> GetBooking(int UserID, int PageNumber, int RecordPerPage)
        {
            GetBookingResponse response = new GetBookingResponse();
            response.IsSuccess = true;
            response.Message = "Get Booking List Successfully";
            try
            {
                response.data = new List<BookingDetails>();
                response.data = _applicationDbContext
                    .Bookingtable.Where(X => X.UserID == UserID)
                    .Skip((PageNumber - 1) * RecordPerPage)
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
                                    .Bookingtable
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

        public async Task<GetProfileDetailsResponse> GetProfileDetails(int UserID)
        {
            GetProfileDetailsResponse response = new GetProfileDetailsResponse();
            response.IsSuccess = true;
            response.Message = "Get Booking List Successfully";
            try
            {
                response.data = new ProfileDetails();
                response.data = _applicationDbContext
                    .ProfileDetailstables.Where(X => X.UserID == UserID)
                    .FirstOrDefault();

                if (response.data == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Is Not Found.";
                    return response;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> UpdateBooking(UpdateBookingRequest request)
        {

            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Booking Successfully";
            try
            {

                var BikeStatus = _applicationDbContext.Vehicletable.Where(X => X.VehicleID == request.VehicleID).FirstOrDefault();
                if (BikeStatus == null)
                {
                    response.IsSuccess = true;
                    response.Message = "Bite Details Not Present.";
                    return response;
                }

                var data = _applicationDbContext.Bookingtable.FindAsync(request.BookingID);
                if (data.Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Booking ID Not Found.";
                    return response;
                }

                Random _rdm = new Random();
                int OtpNumber = _rdm.Next(100000, 999999);

                SendInvoiceMailRequest EmailRequest = new SendInvoiceMailRequest() { 
                    ToEmailID = request.EmailID, 
                    Otp = OtpNumber, 
                    UserName = request.UserName,
                    TotalPrice=request.TotalPrice.ToString(),
                    BookingDate_Time = request.BookingDate,
                    VehicleName = request.VehicleName,
                    Total_Day = request.TotalDistance.ToString(),
                };

                var EmailResponse = await SendInvoiceMail(EmailRequest);

                data.Result.UserID = request.UserID;
                data.Result.TotalPrice = request.TotalPrice;
                data.Result.EmailID = request.EmailID;
                data.Result.UserName = request.UserName;
                data.Result.MobileNumber = request.MobileNumber;
                data.Result.BookingDate = request.BookingDate;
                data.Result.Hub = request.Hub;
                data.Result.TotalDistance = request.TotalDistance;
                data.Result.Status = request.Status;
                data.Result.Driver = request.DriverName;
                data.Result.VehicleID = request.VehicleID;
                data.Result.VehicleName = request.VehicleName;
                data.Result.VehicleNumber = request.VehicleNumber;
                data.Result.VehicleDescription = request.VehicleDescription;
                data.Result.BikeCompany = request.BikeCompany;
                data.Result.PricePerKm = request.PricePerKm;
                data.Result.ImageUrl = request.ImageUrl;
                data.Result.Otp = OtpNumber.ToString();
                data.Result.OtpStatus = EmailResponse.Message;

                BikeStatus.Quantity = BikeStatus.Quantity - 1;

                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;

        }

        public async Task<BasicResponse> UpdateProfileDetails(AddProfileDetailsRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Profile Details Successfully";
            try
            {

                var data = _applicationDbContext.ProfileDetailstables.Where(X => X.UserID == request.UserID).FirstOrDefault();
                if (data == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User ID Not Found.";
                    return response;
                }

                data.Address = request.Address;
                data.Pincode = request.Pincode;
                data.MobileNumber = request.MobileNumber;
                data.EmailID = request.EmailID;

                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        private async Task<SendInvoiceMailResponse> SendInvoiceMail(SendInvoiceMailRequest request)
        {
            SendInvoiceMailResponse response = new SendInvoiceMailResponse();
            response.IsSuccess = true;
            response.Message = "Send Invoice Mail Successfully";

            try
            {
                string to = request.ToEmailID; //To address    
                string from = "bikerentalsystem.cdac@gmail.com"; //From address    
                MailMessage message = new MailMessage(from, to);

                string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
                message.Subject = "Bike Rental System InVoice Mail.";
                message.Body = HtmlBody(request);
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("bikerentalsystem.cdac@gmail.com", "pyigtvniwfcoyqfy");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                try
                {
                    client.Send(message);
                }

                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Exception Message : " + ex.Message;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        private string HtmlBody(SendInvoiceMailRequest request)
        {
            return @"

                    <html>
                        <head>
                            <style>
                                #Container {
                                    height: 100%;
                                    width: 100%;
                                }

                                #SubContainer {
                                    height: 200px;
                                    width: 580px;
                                    border: 0.5px solid lightgray;
                                    padding: 10px 20px;
                                    font-family: Sans-serif;
                                    box-shadow: 0 0 8px -2px black;
                                    display: flex;
                                    justify-content: center;
                                    align-items: center;
                                    flex-direction: column;
                                    background-color: linen;
                                    margin: 20px;
                                }

                                #Header {
                                    font-size: 28px;
                                    font-weight: 525;
                                    color: blue;
                                    height: 10%;
                                    margin: 15px;
                                    font-weight: 500;
                                }

                                #SubHeader {
                                    color: green;
                                    font-weight: 550;
                                    margin: 10px;
                                }

                                #Body {
                                    height: 82%;
                                }

                                #Footer {
                                    height: 8%;
                                    font-weight: 500;
                                    color: rgb(101, 101, 101);
                                    text-decoration: underline;
                                    margin: 10px;
                                    text-transform: capitalize;
                                }
                            </style>
                        </head>

                        <body>
                            <div id='Container'>

                                <div id='SubContainer'>
                                    <div id='Header'>InVoice Details</div>
                                    <div id='Body'>
                                        <div>UserName : "+request.UserName+ @" </div>
                                        <div>Vehicle Name : "+request.VehicleName+ @" </div>
                                        <div>Total Price : "+request.TotalPrice+ @" </div>
                                        <div>Booking Date & Time : "+request.BookingDate_Time+ @" </div>
                                        <div>Total Day : "+request.Total_Day+ @"</div>
                                    </div>
                                </div>

                                <div id='SubContainer'>
                                    <div id='Header'>Bike Rental System</div>
                                    <div id='SubHeader'>Your One Time Password Is : "+request.Otp+@"</div>
                                    <div id='Footer'>When this message not belong to you then please ignore this message.</div>
                                </div>
                            </div>
                        </body>

                    </html>

";
        }

        public async Task<GetVehicle> SearchBikeRecord(SearchBikeRecordRequest request)
        {
            GetVehicle response = new GetVehicle();
            response.IsSuccess = true;
            response.Message = "Get Vehicle List Successfully";
            try
            {
                response.data = new List<VehicleDetails>();
                if (request.BikeCompany.ToLower() == "all")
                {
                    response.data = _applicationDbContext
                        .Vehicletable
                        .Skip((request.PageNumber - 1) * request.RecordPerPage)
                        .Take(request.RecordPerPage)
                        .OrderByDescending(X => X.VehicleID)
                        .ToList();
                }
                else
                {
                    response.data = _applicationDbContext
                        .Vehicletable
                        .Where(X => X.BikeCompany.ToLower() == request.BikeCompany.ToLower())
                        .Skip((request.PageNumber - 1) * request.RecordPerPage)
                        .Take(request.RecordPerPage)
                        .OrderByDescending(X => X.VehicleID)
                        .ToList();
                }

                if (response.data.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Is Not Found.";
                    return response;
                }
                double TotalRecord = 0;
                if (request.BikeCompany.ToLower() == "all")
                {
                    TotalRecord = _applicationDbContext
                                    .Vehicletable
                                    .Count();
                }
                else
                {
                    TotalRecord = _applicationDbContext
                                    .Vehicletable.Where(X => X.BikeCompany.ToLower() == request.BikeCompany.ToLower())
                                    .Count();
                }

                response.TotalPages = (int)Math.Ceiling((double)(TotalRecord / request.RecordPerPage));

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
