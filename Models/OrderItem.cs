using System;
namespace eCommerce.Models
{
    public class OrderItem
    {
        public string cart_guid { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int qty { get; set; }
        //public int product_price { get; set; }
        public int price { get; set; }
    }
}
