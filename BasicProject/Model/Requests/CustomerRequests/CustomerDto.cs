using BasicProject.Model.Requests.CustomerRequests;

namespace BasicProject.Model.Requests.Customer
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; } 

        public AddressDto Address { get; set; }
    }
}
