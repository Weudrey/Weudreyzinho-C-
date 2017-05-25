using Model.Tables;
using Services.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WeudreYZukowski.Controllers.API
{
    public class CategoriesController : ApiController
    {
        private CategoryService service = new CategoryService();
        // GET: api/Categories
        public IEnumerable<Category> Get()
        {
            return service.CategoryByName();
        }

        // GET: api/Categories/5
        public Category Get(int id)
        {
            return service.CategoryById(id);
        }

        // POST: api/Categories
        public void Post([FromBody]Category value)
        {
            service.SaveCategory(value);
        }

        // PUT: api/Categories/5
        public void Put(int id, [FromBody]Category value)
        {
            service.SaveCategory(value);
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
            service.DeleteCategory(id);
        }
    }
}
