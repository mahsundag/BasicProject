using BasicProject.Data;
using BasicProject.Model;
using BasicProject.Model.Requests.Customer;
using BasicProject.Model.Response;

namespace BasicProject.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly BasicProjectDbContext _context;
        public CustomerService(BasicProjectDbContext context)
        {
            _context= context;
        }
        public CustomRespose GetCustomerById(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return new() { Model = null, Message = "There is no Customer has that Id!" };
            }
           return new() { Model = customer, Message = string.Empty };
        }



        public CustomRespose GetCustomerByName(string name)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Name == name);
            if (customer==null)
            {
              return new() { Model = null, Message = "There is no Customer has that name!" };
            }
            return new() { Model = customer, Message = string.Empty };
        }

        public CustomRespose CreateCustomer(CustomerDto createCustomer)
        {
            try
            {
                var adress = new Address
                {
                    City = createCustomer.Address.City,
                    Street = createCustomer.Address.Street,
                    ZipCode = createCustomer.Address.ZipCode,

                };
                var customer = new Customer
                {
                    FirstName = createCustomer.FirstName,
                    LastName = createCustomer.LastName,
                    Name = createCustomer.FirstName + createCustomer.LastName,
                    PhoneNumber = createCustomer.PhoneNumber,
                    Address = adress
                };
                _context.Customers.Add(customer);
                _context.SaveChanges();
               

                return new CustomRespose() { Model = GetCustomerList(), Message = string.Empty };
            }
            catch
            {
                return new CustomRespose() { Model = null, Message = "Create Error " };
            }
        }

       

        public CustomRespose UpdateCustomer(CustomerDto updateCustomer)
        {
            try
            {
                var adress = new Address
                {
                    Id= updateCustomer.Address.AdressId,
                    City = updateCustomer.Address.City,
                    Street = updateCustomer.Address.Street,
                    ZipCode = updateCustomer.Address.ZipCode,

                };
                var customer = new Customer
                {
                    Id=updateCustomer.CustomerId,
                    FirstName = updateCustomer.FirstName,
                    LastName = updateCustomer.LastName,
                    Name = updateCustomer.FirstName + updateCustomer.LastName,
                    PhoneNumber = updateCustomer.PhoneNumber,
                    Address = adress
                };
                var updatedOrder = _context.Customers.Update(customer);
                _context.SaveChanges();
                
                return new CustomRespose() { Model = GetCustomerList(), Message = string.Empty };
            }
            catch
            {
                return new CustomRespose() { Model = null, Message = "Update Error " };
            }
        }

        private List<CustomerResponseDto> GetCustomerList()
        {
            List<CustomerResponseDto> customerResponse = new List<CustomerResponseDto>();
            var query = from c in _context.Customers
                        join a in _context.Addresses
                        on c.AdressId equals a.Id
                        select new
                        {
                            CustomerId = c.Id,
                            CustomerName = c.Name,
                            PhoneNumber = c.PhoneNumber,
                            City = a.City,
                            Street = a.Street,
                            ZipCode = a.ZipCode

                        };

            foreach (var item in query)
            {
                customerResponse.Add(new CustomerResponseDto
                {
                    CustomerId = item.CustomerId,
                    CustomerName = item.CustomerName,
                    PhoneNumber = item.PhoneNumber,
                    City = item.City,
                    Street = item.Street,
                    ZipCode = item.ZipCode
                });
            }
            return customerResponse;
        }
    }
}
