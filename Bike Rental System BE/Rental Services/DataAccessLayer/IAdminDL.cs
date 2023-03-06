using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.DataAccessLayer
{
    public interface IAdminDL
    {
        public Task<BasicResponse> AddVehicle(AddVehicleRequest request);

        public Task<BasicResponse> UpdateVehicle(UpdateVehicleRequest request);

        public Task<GetVehicle> GetVehicle(int PageNumber, int RecordPerPage);

        public Task<BasicResponse> DeleteVehicle(int VehicleID);

        public Task<GetBookingResponse> GetAllBooking(int PageNumber, int RecordPerPage);

        public Task<BasicResponse> UpdateBookingStatus(int BookingID, string Status);

        public Task<GetAllCustomerListResponse> GetAllCustomerList(string Role, int PageNumber, int RecordPerPage);
        public Task<BasicResponse> UpdateCustomerAcceptanceStatus(int CustomerID, bool Status);

        public Task<GetGraphResponse> GetGraph();

        //Hub

        public Task<BasicResponse> AddHub(AddHubRequest request);
        public Task<BasicResponse> UpdateHub(UpdateHubRequest request);
        public Task<GetHubResponse> GetHub(int PageNumber, int RecordPerPage);
        public Task<GetHubResponse> GetAllHubList();

        public Task<BasicResponse> DeleteHub(int HubID);
    }
}
