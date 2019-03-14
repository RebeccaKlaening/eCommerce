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

    public List<Cart> Get()
    {
      using (var connection = new SQLiteConnection(this.connectionString))
      {
        return connection.Query<Cart>("SELECT * FROM CartCustomer").ToList();
      }
    }

    public Cart Get(int id)
    {
      using (var connection = new SQLiteConnection(this.connectionString))
      {
        return connection.QuerySingleOrDefault<Cart>("SELECT * FROM CartCustomer WHERE Id = @Id", new { id });
      }

      }


    }
      
}
