using Model.Tables;
using Services.Registers;
using Services.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeudreYZukowski.Models;

namespace WeudreYZukowski.Controllers.API
{
    public class CategoriesController : ApiController
    {
        private CategoryService service = new CategoryService();
        private ProductServices productService = new ProductServices();

        // GET: api/Categories
        public CategoryListAPIModel Get()
        {
            var apiModel = new CategoryListAPIModel();
            try
            {
                apiModel.Result = service.CategoryByName();
            }
            catch (System.Exception)
            {
                apiModel.Message = "!Ok";
            }
            return apiModel;
        }

        // GET: api/Categories/5
        public CategoryAPIModel Get(int id)
        {
            var apiModel = new CategoryAPIModel();
            try
            {
                apiModel.Result = service.CategoryById(id);
                if(apiModel.Result = null)
                {
                    apiModel.Result.Products = productService.ProductsById(id).ToList();
                }
            }
            catch
            {

            }
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
