using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Services.Model;
using Rental_Services.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSL _userSL;
        public UserController(IUserSL adminSL)
        {
            _userSL = adminSL;
        }
        //AddBooking, UpdateBooking, GetBooking, DeleteBooking
        [HttpPost]
        public async Task<IActionResult> AddBooking(AddBookingRequest request)
        {
            BasicResponse response = new BasicResponse();

            try
            {
                response = await _userSL.AddBooking(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking(UpdateBookingRequest request)
        {
            BasicResponse response = new BasicResponse();

            try
            {
                response = await _userSL.UpdateBooking(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooking([FromQuery] int UserID, int PageNumber, int RecordPerPage)
        {
            GetBookingResponse response = new GetBookingResponse();

            try
            {
                response = await _userSL.GetBooking(UserID, PageNumber, RecordPerPage);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking([FromQuery] int BookingID)
        {
            BasicResponse response = new BasicResponse();

            try
            {
                response = await _userSL.DeleteBooking(BookingID);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfileDetails(AddProfileDetailsRequest request)
        {
            BasicResponse response = new BasicResponse();

            try
            {
                response = await _userSL.AddProfileDetails(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfileDetails(AddProfileDetailsRequest request)
        {
            BasicResponse response = new BasicResponse();

            try
            {
                response = await _userSL.UpdateProfileDetails(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProfileDetails([FromQuery] int UserID)
        {
            GetProfileDetailsResponse response = new GetProfileDetailsResponse();

            try
            {
                response = await _userSL.GetProfileDetails(UserID);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SearchBikeRecord(SearchBikeRecordRequest request)
        {
            GetVehicle response = new GetVehicle();

            try
            {
                response = await _userSL.SearchBikeRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }


    }
}
