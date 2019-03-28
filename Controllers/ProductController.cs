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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly string connectionString;
        private readonly ProductsService productsService;

        public ProductController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.productsService = new ProductsService(new ProductsRepository(connectionString));
        }

        public object ProductsService { get; private set; }

        [HttpGet]
        [ProducesResponseType(typeof(List<Products>), StatusCodes.Status200OK)]
        public IActionResult Get()

        {
            return Ok(this.productsService.Get());
        }


        [HttpGet("{key}")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public IActionResult Get(int key)
        {
            var result = this.productsService.Get(key);
            return Ok(result);
        }

    }
}