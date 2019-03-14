using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using eCommerce.Models;

namespace eCommerce.Repositories
{
    public class ProductsRepository
    {
        private readonly string connectionString;

        public ProductsRepository(string connectionstring)
        {
            this.connectionString = connectionstring; 
        }

        public List<Products> Get()
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<Products>("SELECT * FROM products").ToList();
            }
        }


        public Products Get(int id)
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Products>("SELECT * FROM products WHERE Id = @Id", new { id });
            }

        }


    }
}
