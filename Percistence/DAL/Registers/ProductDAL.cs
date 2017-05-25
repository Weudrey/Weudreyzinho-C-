using Model.Registers;
using Model.Tables;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percistence.DAL.Registers
{
    public class ProductDAL
    {
        private EFContexts context = new EFContexts();
        public IEnumerable<Product> ProductsByName()
        {
            return context.Products.Include(c => c.Category).Include(f => f.Supplier).OrderBy(n => n.Name);
        }
        public Product ProductsById(long id)
        {
            return context.Products.Where(p => p.ProductID == id).Include(c => c.Category).Include(f =>f.Supplier).First();
        }
        public void SaveProduct(Product product)
        {
            if (product.ProductID == null)
            {
                context.Products.Add(product);
            }
            else
            {
                context.Entry(product).State =EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Product DeleteProduct(long id)
        {
            Product product = ProductsById(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return product;
        }
    }
}
