using System;
using System.Collections.Generic;
using eCommerce.Models;
using eCommerce.Repositories;

namespace eCommerce.Services

{
    public class ProductsService
    {
        private readonly IProductsRepository productRepository;
        private object productsRepository;

        public ProductsService(IProductsRepository productRepository)
        {
            this.productRepository = productRepository; 

        }

        public List<Products> Get()
        {
            return this.productRepository.Get(); 
        }


        public Products Get(int key)
        {
            return this.productRepository.Get(key);
        }


    }
}
