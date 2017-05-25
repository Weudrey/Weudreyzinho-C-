using Model.Tables;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percistence.DAL.Tables
{
    public class CategoryDAL
    {
        private EFContexts context = new EFContexts();

        public IEnumerable<Category> CategoriesByName()
        {
            return context.Categories.OrderBy(c => c.Name);
        }
        public Category CategoriesById(long id)
        {
            return context.Categories.Where(b => b.CategoryID == id ).First();
        }
        public void SaveCategory(Category category)
        {
            if (category.CategoryID == null)
            {
                context.Categories.Add(category);
            }
            else
            {
                context.Entry(category).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Category DeleteCategory(long id)
        {
            Category category = CategoriesById(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return category;
        }
    }
}
