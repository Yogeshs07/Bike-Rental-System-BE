using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Data
{
    public class AuthDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string InsertionDate { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string FileName { get; set; }

        public string LicenceImageUrl { get; set; }

        public string DateOfBirth { get; set; }

        public bool IsAccept { get; set; }
    }

    public class VehicleDetails
    {
        //VehicleID InsertionDate VehicleName VehicleNumber VehicleDescription TotalPrice
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleID { get; set; }

        public string InsertionDate { get; set; } = DateTime.Now.ToString("dd-MMM-yyyy");

        public string VehicleName { get; set; } = string.Empty;

        public string VehicleNumber { get; set; } = string.Empty;

        public string VehicleDescription { get; set; } = string.Empty;

        public string BikeCompany { get; set; }

        public int Price { get; set; }

        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }

    public class BookingDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }
        public string InsertionDate { get; set; } = DateTime.Now.ToString("dd-MMM-yyyy");
        public int UserID { get; set; }
        //Vehicle Detail
        // VehicleID, VehicleName, VehicleNumber, VehicleDescription, PricePerKm, ImageUrl
        public int VehicleID { get; set; }
        public string VehicleName { get; set; } = string.Empty;
        public string VehicleNumber { get; set; } = string.Empty;
        public string VehicleDescription { get; set; } = string.Empty;
        public string BikeCompany { get; set; }
        public int PricePerKm { get; set; }
        public string ImageUrl { get; set; }
        //
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string BookingDate { get; set; }
        public string Hub { get; set; }
        public int TotalPrice { get; set; }
        public string TotalDistance { get; set; }
        public string Driver { get; set; }
        public string Status { get; set; }
        public string Otp { get; set; }
        public string OtpStatus { get; set; }
        public bool IsVerified { get; set; }
        public string IsActive { get; set; }
    }

    public class HubDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HubID { get; set; }
        public string InsertionDate { get; set; } = DateTime.Now.ToString("dd-MMM-yyyy");
        public string HubName { get; set; }
    }

    public class ProfileDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ProfileID { get; set; }
        public int UserID { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
    }
}

