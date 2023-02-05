using BasicProject.Model;
using BasicProject.Model.Requests.Customer;

namespace BasicProject.Services.CustomerServices
{
    public interface ICustomerService
    {
        public CustomRespose GetCustomerById(int id);
        public CustomRespose GetCustomerByName(string name);
        public CustomRespose CreateCustomer(CustomerDto customer);
        public CustomRespose UpdateCustomer(CustomerDto customer);
    }
}
