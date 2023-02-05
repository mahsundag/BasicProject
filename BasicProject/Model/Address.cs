using System.ComponentModel.DataAnnotations.Schema;

namespace BasicProject.Model
{
    public class Address:BaseModel
    {
     
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public Customer Customer { get; set; }

    }
}
