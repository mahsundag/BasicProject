using System.ComponentModel.DataAnnotations.Schema;

namespace BasicProject.Model.Requests.CustomerRequests
{
    public class AddressDto
    {
        public int AdressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
           
    }
}
