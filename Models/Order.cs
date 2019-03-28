using System;
using System.Collections.Generic;

namespace eCommerce.Models
{
    public class Order
    {
        public List<OrderItem> OrderItems { get; set; }
        public Customers Customer { get; set; }
    }
}
