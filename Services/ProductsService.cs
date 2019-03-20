using System;
using System.Collections.Generic;
using eCommerce.Models;
using eCommerce.Repositories;

namespace eCommerce.Services

{
    public class ProductsService
    {
        private readonly ProductsRepository productRepository;
        private object productsRepository;

        public ProductsService(ProductsRepository productRepository)
        {
            this.productRepository = productRepository; 

        }

        public List<Products> Get()
        {
            return this.productRepository.Get(); 
        }


        public List<Products> Get(string key)
        {
            return this.productRepository.Get(key);
        }


        //public Products Get(int id)
        //{

        //    if (id < 1)
        //    {
        //        return null;
        //    }

        //    return this.productRepository.Get(id);
        //}

    }
}
