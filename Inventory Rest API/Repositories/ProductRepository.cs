using Inventory_Rest_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstWithRepositoryPattern.Repository
{
    public class ProductRepository:Repository<Product>
    {

      //  InventoryDB context = new InventoryDB();
        public List<Product> TopPrice(int top)
        {
            return this.GetAllData().OrderByDescending(x => x.Price).Take(top).ToList();
        }

    }
}