using BasicProject.Model;

namespace BasicProject.Services.AddressServices
{
    public interface IAdressService
    {
        public CustomRespose GetAddressByCustomerName(string customerName);

    }
}
