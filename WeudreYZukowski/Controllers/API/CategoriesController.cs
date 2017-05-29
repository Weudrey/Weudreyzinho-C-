using Model.Tables;
using Services.Registers;
using Services.Tables;
using System.Linq;
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
                apiModel.Result = service.GetByName().ToList();
            }
            catch (System.Exception)
            {
                apiModel.Message = "!OK";
            }

            return apiModel;
        }
      
        // GET: api/Categories/5
        public CategoryAPIModel Get(long? id)
        {
            var apiModel = new CategoryAPIModel();

            try
            {
                if (id == null)
                {
                    apiModel.Message = "!OK";
                    return apiModel;
                }
                else
                {
                    apiModel.Result = service.GetByID(id);
                    if (apiModel.Result != null)
                        apiModel.Result.Products = productService.GetByCategory(id.Value).ToList();
                }
            }
            catch (System.Exception)
            {
                apiModel.Message = "!OK";
            }

            return apiModel;
        }

        // POST: api/Categories
        public void Post([FromBody]Category value)
        {
            service.Save(value);
        }

        // PUT: api/Categories/5
        public void Put(int id, [FromBody]Category value)
        {
            service.Save(value);
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
            service.DeleteByID(id);
        }
    }
}
