using System;
using System.Collections.Generic;
using eCommerce.Models;
using eCommerce.Repositories;

namespace eCommerce.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;

        }


        public List<Customers> Get()
        {
            return this.customerRepository.Get();
        }


        public Customers Get(string guid)
        {
            return this.customerRepository.Get(guid);
        }


        public bool Add(Customers customers)
        {
            if(customers!=null)
            {
                this.customerRepository.Add(customers);
                return true;
            }


            return false;

        }   
    }
}