using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using eCommerce.Models;

namespace eCommerce.Repositories
{
    public class CartRepository 
    
    {
 
    private readonly string connectionString;
        public CartRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }


        public List<Cart> Get(string guid)
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<Cart>("SELECT cartItems.id, product_id, cart_quantity, cart_guid, product_name, product_image, product_description, product_price FROM cartItems LEFT JOIN products ON cartItems.product_id = products.id WHERE cart_guid = @guid", new { guid }).ToList();
            }

        }

    }
      
}
