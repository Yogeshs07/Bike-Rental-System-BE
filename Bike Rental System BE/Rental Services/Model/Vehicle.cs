using Microsoft.AspNetCore.Http;
using Rental_Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Model
{
    public class AddVehicleRequest
    {
        public string VehicleName { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleDescription { get; set; }
        public string BikeCompany { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public IFormFile File { get; set; }
    }

    public class UpdateVehicleRequest
    {
        public int VehicleID { get; set; }
        public string VehicleName { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleDescription { get; set; }
        public string BikeCompany { get; set; }
        public int Price { get; set; }
        public String ImageUrl { get; set; }
        public int Quantity { get; set; }
    }

    public class GetVehicle
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalPages { get; set; }
        public List<VehicleDetails> data { get; set; }
    }

    public class GetGraphResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<GetGraph> PendingData { get; set; }
        public List<GetGraph> SuccessData { get; set; }
        public List<GetGraph> RejectData { get; set; }
        public List<GetGraph> CancelData { get; set; }
    }

    public class GetGraph
    {
        public string label { get; set; }
        public int value { get; set; }
    }
}
