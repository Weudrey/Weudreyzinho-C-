using Model.Tables;
using Percistence.DAL.Tables;
using System.Collections.Generic;
using System.Linq;


namespace Services.Tables
{
    public class CategoryService
    {
        private CategoryDAL categoryDAL = new CategoryDAL();
        public IEnumerable<Category> CategoryByName()
        {
            return categoryDAL.CategoriesByName();
        }

        public Category CategoryById(long id)
        {
            return categoryDAL.CategoriesById(id);
        }
        public void SaveCategory(Category supplier)
        {
            categoryDAL.SaveCategory(supplier);
        }
        public Category DeleteCategory(long id)
        {
            return categoryDAL.DeleteCategory(id);
        }

    }
}
