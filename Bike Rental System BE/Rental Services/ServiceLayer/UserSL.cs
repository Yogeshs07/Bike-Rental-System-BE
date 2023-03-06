using Rental_Services.DataAccessLayer;
using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.ServiceLayer
{
    public class UserSL : IUserSL
    {
        private readonly IUserDL _userDL;
        public UserSL(IUserDL userDL)
        {
            _userDL = userDL;
        }

        public async Task<BasicResponse> AddBooking(AddBookingRequest request)
        {
            return await _userDL.AddBooking(request);
        }

        public async Task<BasicResponse> AddProfileDetails(AddProfileDetailsRequest request)
        {
            return await _userDL.AddProfileDetails(request);
        }

        public async Task<BasicResponse> DeleteBooking(int BookingID)
        {
            return await _userDL.DeleteBooking(BookingID);
        }

        public async Task<GetBookingResponse> GetBooking(int UserID, int PageNumber, int RecordPerPage)
        {
            return await _userDL.GetBooking(UserID, PageNumber, RecordPerPage);
        }

        public async Task<GetProfileDetailsResponse> GetProfileDetails(int UserID)
        {
            return await _userDL.GetProfileDetails(UserID);
        }

        public async Task<GetVehicle> SearchBikeRecord(SearchBikeRecordRequest request)
        {
            return await _userDL.SearchBikeRecord(request);
        }

        public async Task<BasicResponse> UpdateBooking(UpdateBookingRequest request)
        {
            return await _userDL.UpdateBooking(request);
        }

        public async Task<BasicResponse> UpdateProfileDetails(AddProfileDetailsRequest request)
        {
            return await _userDL.UpdateProfileDetails(request);
        }
    }
}
