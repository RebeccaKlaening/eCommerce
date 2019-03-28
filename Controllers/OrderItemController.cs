using System.Collections.Generic;
using eCommerce.Models;
using eCommerce.Repositories;
using System.Linq;
using eCommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    public class OrderItemController : Controller
    {
        private readonly string connectionString;
        private readonly OrderItemService orderItemService;


        public OrderItemController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.orderItemService = new OrderItemService(new OrderItemRepository(connectionString),new CustomerRepository(connectionString));
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(List<OrderItem>), StatusCodes.Status200OK)]
        public IActionResult Get(string guid)

        {
            return Ok(this.orderItemService.Get(guid));
        }


    }
}