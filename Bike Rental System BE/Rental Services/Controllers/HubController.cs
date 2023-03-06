using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Services.DataAccessLayer;
using Rental_Services.Model;
using System;
using System.Threading.Tasks;

namespace Rental_Services.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class HubController : ControllerBase
    {

        private readonly IAdminDL _adminDL;
        public HubController(IAdminDL adminDL)
        {
            _adminDL = adminDL;
        }

        [HttpPost]
        public async Task<IActionResult> AddHub(AddHubRequest request)
        {
            BasicResponse response = new BasicResponse();

            try
            {
                response = await _adminDL.AddHub(request); 
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHub(UpdateHubRequest request)
        {
            BasicResponse response = new BasicResponse();

            try
            {
                response = await _adminDL.UpdateHub(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetHub([FromQuery]int PageNumber, int RecordPerPage)
        {
            GetHubResponse response = new GetHubResponse();

            try
            {
                response = await _adminDL.GetHub(PageNumber, RecordPerPage);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHubList()
        {
            GetHubResponse response = new GetHubResponse();

            try
            {
                response = await _adminDL.GetAllHubList();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteHub([FromQuery] int HubID)
        {
            BasicResponse response = new BasicResponse();

            try
            {
                response = await _adminDL.DeleteHub(HubID);
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
