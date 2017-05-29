using Model.Registers;
using Percistence.DAL.Registers;
using System.Linq;

namespace Services.Registers
{
    public class ProductServices
    {
        private ProductDAL productDAL = new ProductDAL();
        public IQueryable GetByName()
        {
            return productDAL.ProductsByName();
        }
        public Product GetByID(long id)
        {
            return productDAL.ProductsById(id);
        }
        public IQueryable<Product> GetByCategory(long? id)
        {
            return productDAL.GetByCategory(id);
        }
        public void Save(Product product)
        {
            productDAL.SaveProduct(product);
        }
        public Product DeleteByID(long id)
        {
            return productDAL.DeleteProduct(id);
        }
    }
}
