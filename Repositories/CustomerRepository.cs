using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using eCommerce.Models;

namespace eCommerce.Repositories
{
    public class CustomerRepository

    {

        private readonly string connectionString;

        public CustomerRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }


        public List<Customers> Get()
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<Customers>("SELECT * FROM [Order]").ToList();
            }
        }


        public Customers Get(string guid)
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Customers>("SELECT * FROM [Order] WHERE cart_id = @guid", new { guid });
            }   

        }

        public void Add(Customers customers)
        {
                using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                connection.Execute(
                "INSERT INTO [Order](id, name_customer, adress_customer, date, cart_id) VALUES (@id, @name_customer, @adress_customer, @date, @cart_id)", 
                    customers);
            }
        
        }

    }

}
