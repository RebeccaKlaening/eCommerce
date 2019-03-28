using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using eCommerce.Models;

namespace eCommerce.Repositories
{
    public class CartItemRepository

    {

        private readonly string connectionString;
        public CartItemRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }


        public List<CartItem> Get()
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<CartItem>("SELECT * FROM cartItems").ToList(); 
            }
        }


        public List<CartItem> Get(string guid)
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<CartItem>("SELECT cart_guid, COUNT(product_id) AS items FROM cartItems WHERE cart_guid = @guid", new { guid }).ToList();
            }
        }


        public void Add(CartItem cartItem)
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO cartItems (cart_id, product_id, cart_quantity, cart_guid, product_guid) VALUES (@cart_id, @product_id, @cart_quantity, @cart_guid, @product_guid)", cartItem);
            }
        }


    }

}
