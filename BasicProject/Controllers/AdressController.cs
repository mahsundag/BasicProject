using BasicProject.Model;
using BasicProject.Services.AddressServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace BasicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly IAdressService _adressService;
        public AdressController(IAdressService adressService)
        {
            _adressService= adressService;
        }

        /// <summary>
        /// Get Address By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        [HttpGet]
        [SwaggerOperation(Summary = "Get Address By Name", Description = "Get Address By Name")]
        public ActionResult<Address> GetAddressByName(string name)
        {
            var address = _adressService.GetAddressByCustomerName(name);
            if (address.Model==null)
            {
                return NotFound(address.Message);
            }
            else return Ok(address.Model);
        }

        
    }
}
