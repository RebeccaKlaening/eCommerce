using System;
using System.Collections.Generic;
using eCommerce.Models;
using eCommerce.Repositories;

namespace eCommerce.Services
{
    public class CartItemService
    {
        private readonly CartItemRepository cartItemRepository;

        public CartItemService(CartItemRepository cartItemRepository)
        {
            this.cartItemRepository = cartItemRepository;

        }


        public List<CartItem> Get()
        {
            return this.cartItemRepository.Get();
        }


        public bool Add(CartItem cartItem)
        {
            this.cartItemRepository.Add(cartItem);
            return true;
        }


        public List <CartItem> Get(string guid)
        {
            return this.cartItemRepository.Get(guid);
        }

    }
}