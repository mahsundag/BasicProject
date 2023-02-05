using BasicProject.Model;
using BasicProject.Model.Requests.OrderRequests;

namespace BasicProject.Services.OrderServices
{
    public interface IOrderService
    {
        public CustomRespose GetOrderById(int id);

        public CustomRespose GetOrderByRecipeNumber(string number);

        public CustomRespose GetOrdersByCustomerName(string name);

        public CustomRespose CreateOrder(OrderDto order);
    }
}
