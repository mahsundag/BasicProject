using BasicProject.Data;
using BasicProject.Model;
using BasicProject.Model.Requests.OrderRequests;
using Microsoft.EntityFrameworkCore;

namespace BasicProject.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly BasicProjectDbContext _context;

        public OrderService(BasicProjectDbContext context) { 
            _context = context;
        }


        public CustomRespose GetOrderById(int id)
        {
            var order = _context.Orders.Find(id);
            if (order==null)
            {
                return new() { Model = null , Message = "There no record with this Id" };
            }
            
            return new() { Model = order , Message = string.Empty };

        }

        public CustomRespose GetOrderByRecipeNumber(string number)
        {
            var order = _context.Orders.SingleOrDefault(o => o.RecipeNumber == number);
            if (order==null)
            {
                return new() { Model = null, Message = "There no record with this Number" };
            }
            return new() { Model = order ,Message = string.Empty};
            
        }
        
        
        public CustomRespose GetOrdersByCustomerName(string name)
        {
            var customer = _context.Customers.FirstOrDefault(x=>x.Name==name);
            if (customer==null)
            {
                return new() { Model = null, Message = "There is no Customer with this name" };
            }
            var order = _context.Orders.SingleOrDefault(o => o.CustomerId == customer.Id);
            if (order==null)
            {
                return new() { Model = null, Message = "This Customer has no recipe" };
            }
            return new() { Model = order, Message = string.Empty };
        }


        public CustomRespose CreateOrder(OrderDto createOrder)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.Id == createOrder.CustomerId);
                if (customer==null)
                {
                    return new CustomRespose() { Model = null, Message = "There is no Customer with this Id " };
                }
                var order = new Order
                {
                    CustomerId=customer.Id,
                    ProductName=createOrder.ProductName,
                    Quantity=createOrder.Quantity,
                    RecipeNumber=createOrder.RecipeNumber
                };
                 _context.Orders.Add(order);
                 _context.SaveChanges();
                return new CustomRespose() { Model = _context.Orders, Message = string.Empty };
            }
            catch
            {
                return new CustomRespose() { Model = null, Message = "Create Error " };
            }
        }
    }
}
