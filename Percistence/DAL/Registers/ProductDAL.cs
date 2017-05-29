using Model.Registers;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Percistence.DAL.Registers
{
    public class ProductDAL
    {
        private EFContexts context = new EFContexts();
        public IQueryable<Product> ProductsByName()
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
        }        public IQueryable<Product> GetByCategory(long? categoryID)
        {
            return context.Products.Where(p => p.CategoryId.HasValue && p.CategoryId.Value == categoryID);
        }
    }
}
