using System;
namespace eCommerce.Models
{
    public class Cart
    {
     
        public int Id { get; set; }
        public int product_id { get; set; }
        public int cart_price { get; set; }
        public int cart_quantity { get; set; }

    }
}
