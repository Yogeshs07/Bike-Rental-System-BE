using Rental_Services.Data;
using System.Collections.Generic;

namespace Rental_Services.Model
{
    public class AddHubRequest
    {
        public string HubName { get; set; }
    }

    public class UpdateHubRequest
    {
        public int HubId { get; set; }
        public string HubName { get; set; }
    }

    public class GetHubResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalPages { get; set; }
        public List<HubDetails> data { get; set; } 
    }
}
