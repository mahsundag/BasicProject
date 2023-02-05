using BasicProject.Model;
using BasicProject.Model.Requests.Customer;
using BasicProject.Model.Response;
using BasicProject.Services.CustomerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace BasicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService= customerService;
        }

        /// <summary>
        /// Get Customer By Name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name")]
        [SwaggerOperation(Summary = "Get Customer By Name",Description = "Write a Customer Name as a Parameter")]
        public ActionResult<Customer> GetCustomerByName(string name)
        {
            var customer = _customerService.GetCustomerByName(name);
            if (customer.Model==null)
            {
                return NotFound(customer.Message);
            }
            return Ok(customer.Model);
        }

        /// <summary>
        /// Get Customer By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        [SwaggerOperation(Summary = "Get Customer By Id", Description = "Write a Customer Id as a Parameter")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer.Model == null)
            {
                return NotFound(customer.Message);
            }
            return Ok(customer.Model);
        }

        /// <summary>
        /// Add New Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Add New Customer", Description = "No need to write Id's")]
        public ActionResult<List<CustomerResponseDto>> AddCustomer(CustomerDto customer)
        {
            var customers = _customerService.CreateCustomer(customer);
            if (customers.Model == null)
            {
                return NotFound(customers.Message);
            }
            return Ok(customers.Model);
        }

        /// <summary>
        /// Update Customer 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation(Summary = "Update Customer", Description = " Id's are Important")]

        public ActionResult<List<CustomerResponseDto>> UpdateCustomer(CustomerDto customer)
        {
            var customers = _customerService.UpdateCustomer(customer);
            if (customers.Model == null)
            {
                return NotFound(customers.Message);
            }
            return Ok(customers.Model);
        }
    }
}
