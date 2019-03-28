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
    public class CartItemController : Controller
    {
        private readonly string connectionString;
        private readonly CartItemService cartItemService;

        public CartItemController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartItemService = new CartItemService(new CartItemRepository(connectionString));
        }

        public object CartItemService { get; private set; }


        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]CartItem cartItem)
        {


            var result = this.cartItemService.Add(cartItem);

            if(!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CartItem>), StatusCodes.Status200OK)]
        public IActionResult Get()

        {
            return Ok(this.cartItemService.Get());
        }


        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(List<CartItem>), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var result = this.cartItemService.Get(guid);
            return Ok(result);
        }

    }



}