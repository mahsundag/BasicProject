using BasicProject.Model;
using BasicProject.Model.Requests.OrderRequests;
using BasicProject.Services.AddressServices;
using BasicProject.Services.OrderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BasicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService= orderService;
        }

        /// <summary>
        /// Get Order By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        [SwaggerOperation(Summary = "Get Order By Id", Description = "Get Order By Id")]

        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order==null)
            {
                return NotFound(order.Message);
            }
            return Ok(order.Model);
        }

        /// <summary>
        /// Get Order By Customer Name
        /// </summary>
        /// <param name="customername"></param>
        /// <returns></returns>
        [HttpGet("customername")]
        [SwaggerOperation(Summary = "Get Order By Customer Name", Description = "Get Order By Customer Name")]
        public IActionResult GetOrderByName(string customername)
        {
            var order = _orderService.GetOrdersByCustomerName(customername);
            if (order == null)
            {
                return NotFound(order.Message);
            }
            return Ok(order.Model);
        }

        /// <summary>
        /// Get Order By Recipe Number
        /// </summary>
        /// <param name="recipeNumber"></param>
        /// <returns></returns>
        [HttpGet("recipeNumber")]
        [SwaggerOperation(Summary = "Get Order By Recipe Number", Description = "Get Order By Recipe Number")]
        public IActionResult GetOrderByNumber(string recipeNumber)
        {
            var order = _orderService.GetOrderByRecipeNumber(recipeNumber);
            if (order == null)
            {
                return NotFound(order.Message);
            }
            return Ok(order.Model);
        }

        /// <summary>
        /// Create New Order
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Create an Order", Description = "Create an Order")]
        public ActionResult<List<Order>> CreateOrder(OrderDto orderDto)
        {
            var orders = _orderService.CreateOrder(orderDto);

            if (orders.Model == null)
            {
                return NotFound(orders.Message);
            }
            return Ok(orders.Model);
        }
    }
}
