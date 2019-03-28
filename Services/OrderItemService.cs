using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using System.Linq;
using eCommerce.Repositories;
using eCommerce.Models;

namespace eCommerce.Services
{
    public class OrderItemService
    {
        private readonly OrderItemRepository orderItemRepository;
        private readonly CustomerRepository customerRepository;

        public OrderItemService(OrderItemRepository orderItemRepository, CustomerRepository customerRepository)
        {
            this.orderItemRepository = orderItemRepository;
            this.customerRepository = customerRepository;
        }


        public Order Get(string guid)
        {

            var orderItems = this.orderItemRepository.Get(guid);
            var customer = this.customerRepository.Get(guid);

            return new Order
            {
                OrderItems = orderItems,
                Customer = customer
            };
        }
    }

}