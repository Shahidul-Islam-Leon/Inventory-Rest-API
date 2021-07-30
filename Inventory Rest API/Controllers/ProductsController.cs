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
    public class ProductsController : ApiController
    {

        ProductRepository pr = new ProductRepository ();


        public IHttpActionResult Get()
        {
            return Ok(pr.GetAllData());
        }
        public IHttpActionResult Get(int id)
        {
            var cat = pr.Get(id);
            if (cat == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(pr.Get(id));
        }
        public IHttpActionResult Post(Product pro)
        {
            pr.Insert(pro);
            return Created("api/Products" + pro.ProductId, pro);
        }
        public IHttpActionResult Put([FromUri] int id, [FromBody] Product pro)
        {
            pro.ProductId = id;
            pr.Update(pro);
            return Ok(pro);
        }
        public IHttpActionResult Delete(int id)
        {

            pr.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
