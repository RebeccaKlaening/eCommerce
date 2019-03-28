using System;
namespace eCommerce.Models
{
    public class CartItem
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int cart_id { get; set; }
        public int cart_quantity { get; set; }
        public string cart_guid { get; set; }
        public string product_guid { get; set; }
        public int items { get; set; }

    }
}
