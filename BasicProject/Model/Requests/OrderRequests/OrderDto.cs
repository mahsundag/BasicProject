using System.ComponentModel.DataAnnotations.Schema;

namespace BasicProject.Model.Requests.OrderRequests
{
    public class OrderDto
    {
        public string RecipeNumber { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
    }
}
