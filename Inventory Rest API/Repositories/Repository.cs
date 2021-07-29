using Inventory_Rest_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstWithRepositoryPattern.Repository
{
    public class Repository<T> : IRipository<T> where T:class
    {

        InventoryDBContext context = new InventoryDBContext();
        public List<T> GetAllData()
        {
            return this.context.Set<T>().ToList();

        }
        public T Get(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            this.context.Set<T>().Add(entity);
            this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.context.Set<T>().Remove(Get(id));
            this.context.SaveChanges();
        }

        
        
       
        
        
    }
}