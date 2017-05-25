using Model.Registers;
using Percistence.DAL.Registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Registers
{
    public class ProductServices
    {
        private ProductDAL produtoDAL = new ProductDAL();
        public IEnumerable<Product> ProductsByName()
        {
            return produtoDAL.ProductsByName();
        }
        public Product ProductsById(long id)
        {
            return produtoDAL.ProductsById(id);
        }
        public void SaveProduct(Product product)
        {
            produtoDAL.SaveProduct(product);
        }
        public Product DeleteProduct(long id)
        {
            return produtoDAL.DeleteProduct(id);
        }
    }
}
