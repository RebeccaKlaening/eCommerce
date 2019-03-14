using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Models;
using eCommerce.Repositories;
using eCommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly string connectionString;
        private readonly CartService cartService;

        public CartController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartService = new CartService(new CartRepository(connectionString));
        }

        public object CartService { get; private set; }

        [HttpGet]
        [ProducesResponseType(typeof(List<Cart>), StatusCodes.Status200OK)]
        public IActionResult Get()

        {
            return Ok(this.cartService.Get());
        }

    }
}