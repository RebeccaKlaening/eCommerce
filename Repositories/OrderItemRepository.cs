using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using eCommerce.Models;

namespace eCommerce.Repositories
{
    public class OrderItemRepository

    {

        private readonly string connectionString;

        public OrderItemRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }


        public List<OrderItem> Get(string guid)
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<OrderItem>("SELECT cart_guid, product_id, product_name, sum(cart_quantity) AS qty, product_price, SUM(product_price) AS Price FROM cartItems LEFT JOIN products ON cartItems.product_id = products.id WHERE cart_guid = @guid GROUP BY product_id", new { guid }).ToList();
            }
        }
    }

}
