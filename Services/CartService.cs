using System;
using System.Collections.Generic;
using eCommerce.Models;
using eCommerce.Repositories;

namespace eCommerce.Services
{
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;

        }

        public List<Cart> Get()
        {
            return this.cartRepository.Get();
        }

        public Cart Get(int id)
        {

            if (id < 1)
            {
                return null;
            }

            return this.cartRepository.Get(id);
        }


    }
}