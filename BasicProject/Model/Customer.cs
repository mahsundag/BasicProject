using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace BasicProject.Model
{
    public class Customer:BaseModel
    {

        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey(nameof(Address))]
        public int AdressId { get; set; }
        public Address Address { get; set; }
    }
}
