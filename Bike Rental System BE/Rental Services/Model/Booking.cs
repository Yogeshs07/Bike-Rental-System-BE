using Rental_Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Model
{
    public class AddBookingRequest
    {
        //UserID, CustomerName, MobileNumber, Source, Destination, TotalPrice, TotalDistance, Status
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string BookingDate { get; set; }
        public string Hub { get; set; }
        public int TotalPrice { get; set; }
        public string TotalDistance { get; set; }
        public string Status { get; set; }
        // VehicleID, VehicleName, VehicleNumber, VehicleDescription, PricePerKm, ImageUrl
        public int VehicleID { get; set; }
        public string VehicleName { get; set; } = string.Empty;
        public string VehicleNumber { get; set; } = string.Empty;
        public string VehicleDescription { get; set; } = string.Empty;
        public string BikeCompany { get; set; }
        public int PricePerKm { get; set; }
        public string ImageUrl { get; set; }
    }


    public class UpdateBookingRequest
    {
        //UserID, CustomerName, MobileNumber, Source, Destination, TotalPrice, TotalDistance, Status
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string DriverName { get; set; }
        public string BookingDate { get; set; }
        public string Hub { get; set; }
        public int TotalPrice { get; set; }
        public string TotalDistance { get; set; }
        public string Status { get; set; }
        // VehicleID, VehicleName, VehicleNumber, VehicleDescription, PricePerKm, ImageUrl
        public int VehicleID { get; set; }
        public string VehicleName { get; set; } = string.Empty;
        public string VehicleNumber { get; set; } = string.Empty;
        public string VehicleDescription { get; set; } = string.Empty;
        public string BikeCompany { get; set; }
        public int PricePerKm { get; set; }
        public string ImageUrl { get; set; }
    }

    public class GetBookingResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalPages { get; set; }
        public List<BookingDetails> data { get; set; }
    }

    public class AddProfileDetailsRequest
    {
        public int UserID { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
    }

    public class GetProfileDetailsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ProfileDetails data { get; set; }
    }

    public class SendInvoiceMailResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class SendInvoiceMailRequest
    {
        public string ToEmailID { get; set; }
        public int Otp { get; set; }
        public string UserName { get; set; }
        public string VehicleName { get; set; }
        public string TotalPrice { get; set; }
        public string BookingDate_Time { get; set; }
        public string Total_Day { get; set; }

    }

    public class SearchBikeRecordRequest
    {
        public string BikeCompany { get; set; }
        public int PageNumber { get; set; }
        public int RecordPerPage { get; set; }
    }
}
