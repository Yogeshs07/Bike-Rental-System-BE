using Rental_Services.DataAccessLayer;
using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.ServiceLayer
{
    public class AdminSL : IAdminSL
    {
        private readonly IAdminDL _adminDL;
        public AdminSL(IAdminDL adminDL) 
        {
            _adminDL = adminDL;
        }

        public async Task<BasicResponse> AddVehicle(AddVehicleRequest request)
        {
            return await _adminDL.AddVehicle(request);
        }

        
        public async Task<BasicResponse> DeleteVehicle(int VehicleID)
        {
            return await _adminDL.DeleteVehicle(VehicleID);
        }

        public async Task<GetBookingResponse> GetAllBooking(int PageNumber, int RecordPerPage)
        {
            return await _adminDL.GetAllBooking(PageNumber, RecordPerPage);
        }

        public async Task<GetAllCustomerListResponse> GetAllCustomerList(string Role, int PageNumber, int RecordPerPage)
        {
            return await _adminDL.GetAllCustomerList(Role, PageNumber, RecordPerPage);
        }

        public async Task<GetGraphResponse> GetGraph()
        {
            return await _adminDL.GetGraph();
        }

        
        public async Task<GetVehicle> GetVehicle(int PageNumber, int RecordPerPage)
        {
            return await _adminDL.GetVehicle(PageNumber, RecordPerPage);
        }

        public async Task<BasicResponse> UpdateBookingStatus(int BookingID, string Status)
        {
            return await _adminDL.UpdateBookingStatus(BookingID, Status);
        }

        public async Task<BasicResponse> UpdateCustomerAcceptanceStatus(int CustomerID, bool Status)
        {
            return await _adminDL.UpdateCustomerAcceptanceStatus(CustomerID, Status);
        }

        
        public async Task<BasicResponse> UpdateVehicle(UpdateVehicleRequest request)
        {
            return await _adminDL.UpdateVehicle(request);
        }

        // Hub

        public async Task<BasicResponse> AddHub(AddHubRequest request)
        {
            return await _adminDL.AddHub(request);
        }

        public async Task<BasicResponse> DeleteHub(int HubID)
        {
            return await _adminDL.DeleteHub(HubID);
        }

        public async Task<GetHubResponse> GetHub(int PageNumber, int RecordPerPage)
        {
            return await _adminDL.GetHub(PageNumber, RecordPerPage);
        }

        public async Task<BasicResponse> UpdateHub(UpdateHubRequest request)
        {
            return await _adminDL.UpdateHub(request);
        }

        public async Task<GetHubResponse> GetAllHubList()
        {
            return await _adminDL.GetAllHubList();
        }
    }
}
