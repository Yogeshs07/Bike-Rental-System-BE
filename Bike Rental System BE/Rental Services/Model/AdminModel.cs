using System.Collections.Generic;

namespace Rental_Services.Model
{
    public class GetAllCustomerListResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalPages { get; set; }

        public List<GetAllCustomerList> data { get; set;}
    }

    public class GetAllCustomerList
    {
        //UserID, InsertionDate, UserName, Role, IsAccept
        public int UserID { get; set; }
        public string InsertionDate { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string ImageUrl { get; set; }
        public string DateOfBirth { get; set; }
        public string FileName { get; set; }
        public bool IsAccept { get; set; }
    }
}
