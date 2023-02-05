using BasicProject.Data;
using BasicProject.Model;
using BasicProject.Services.CustomerServices;

namespace BasicProject.Services.AddressServices
{
    public class AdressService : IAdressService
    {
        private readonly BasicProjectDbContext _context;
        public AdressService(BasicProjectDbContext context)
        {
            _context = context;
        }


        public CustomRespose GetAddressByCustomerName(string customerName)
        {
            var customer = _context.Customers.SingleOrDefault(a => a.Name == customerName);
            if (customer == null)
            {
                return new CustomRespose
                {
                    Model = null,
                    Message = "There is no Customer with asked Name"
                };
            }
            var address = _context.Addresses.SingleOrDefault(x => x.Id == customer.AdressId);
            if (customer.Address==null)
            {
                return new CustomRespose
                {
                    Model = null,
                    Message = "This Customer has no adress."
                };
            }

            return new CustomRespose
            {
                Model = address,
                Message = "There is no Customer with asked Name"
            };
        }

    }
}
