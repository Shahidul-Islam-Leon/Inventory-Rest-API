using CodeFirstWithRepositoryPattern.Repository;
using Inventory_Rest_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Inventory_Rest_API.Controllers
{
   
    public class CategoriesController : ApiController
    {
        CategoryRepository cr = new CategoryRepository();


        public IHttpActionResult Get()
        {
            return Ok(cr.GetAllData());
        }
        public IHttpActionResult Get(int id)
        {
            var cat = cr.Get(id);
            if (cat==null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(cr.Get(id));
        }
        public IHttpActionResult Post(Category cat)
        {
            cr.Insert(cat);
            return Created("api/Categories"+cat.CategoryId,cat);
        }
         public IHttpActionResult Put([FromUri]int id,[FromBody]Category cat)
        {
            cat.CategoryId = id;
            cr.Update(cat);
            return Ok(cat);
        }
         public IHttpActionResult Delete(int id)
        {
            
            cr.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [Route("api/Categories/{id}/Products")]
        public IHttpActionResult GetProductByCategory(int id)
        {
            ProductRepository pr = new ProductRepository();
            return Ok(pr.GetProductByCategory(id));
        }
        
    }
}
