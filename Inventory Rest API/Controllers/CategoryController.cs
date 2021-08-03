using CodeFirstWithRepositoryPattern.Repository;
using Inventory_Rest_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Inventory_Rest_API.Controllers
{

    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        CategoryRepository cr = new CategoryRepository();


        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(cr.GetAllData());
        }

        [Route("{id}", Name = "GetCategoryById")]
        public IHttpActionResult Get(int id)
        {
            var cat = cr.Get(id);
            if (cat == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            // Dynamically link
            //  cat.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri.ToString(), Method = "Get", Relation = "Self" });
            //or
            cat.Links.Add(new Link() { Url = "https://localhost:44368/api/Categories/1", Method = "Get", Relation = "Self" });

            cat.Links.Add(new Link() { Url = "https://localhost:44368/api/Categories", Method = "Get", Relation = "Get all categories" });
            cat.Links.Add(new Link() { Url = "https://localhost:44368/api/Categories/1", Method = "Post", Relation = "Create new category resource" });
            cat.Links.Add(new Link() { Url = "https://localhost:44368/api/Categories/1", Method = "Put", Relation = "Modify existing category resource" });
            cat.Links.Add(new Link() { Url = "https://localhost:44368/api/Categories/1", Method = "Delete", Relation = "Remove existing category resource" });


            return Ok(cr.Get(id));
        }
        [Route("")]
        public IHttpActionResult Post(Category cat)
        {
            cr.Insert(cat);
            string uri = Url.Link("GetCategoryById", new { id = cat.CategoryId });

            return Created(uri, cat);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Category cat)
        {
            cat.CategoryId = id;
            cr.Update(cat);
            return Ok(cat);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {

            cr.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [Route("{id}/Products")]
        public IHttpActionResult GetProductByCategory(int id)
        {
            ProductRepository pr = new ProductRepository();
            return Ok(pr.GetProductByCategory(id));
        }

    }
}
