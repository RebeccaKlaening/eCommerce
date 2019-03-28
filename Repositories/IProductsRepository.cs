using System;
using System.Collections.Generic;
using eCommerce.Models;

namespace eCommerce.Repositories
{
    public interface IProductsRepository
    {
        List<Products> Get();
        Products Get(int id);

    }
}
