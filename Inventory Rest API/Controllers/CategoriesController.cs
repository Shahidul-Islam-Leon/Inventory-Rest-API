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
    }
}
