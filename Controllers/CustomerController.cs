using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Models;
using eCommerce.Repositories;
using eCommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly string connectionString;
        private readonly CustomerService customerService;


        public CustomerController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.customerService = new CustomerService(new CustomerRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Customers>), StatusCodes.Status200OK)]
        public IActionResult Get()

        {
            return Ok(this.customerService.Get());
        }



        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(Customers), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var result = this.customerService.Get(guid);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Customers customers)
        {
            var result = this.customerService.Add(customers);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}