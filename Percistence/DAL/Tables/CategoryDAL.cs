﻿using Model.Tables;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Percistence.DAL.Tables
{
    public class CategoryDAL
    {
        private EFContexts context = new EFContexts();


        public IQueryable<Category> GetOrderbyName()
        {
            return context.Categories.OrderBy(c => c.Name);
        }
        public IQueryable<Category> Get()
        {
            return context.Categories;
        }

        public Category GetOrderById(long? id)
        {
            return context.Categories.Where(c => c.CategoryID == id).First(); //.Include("Products.Supplier").First();
        }
        public void SaveProduct(Category category)
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
        public Category DeleteByID(long id)
        {
            Category category = GetOrderById(id);
            context.Products.RemoveRange(context.Products).Where(m => m.CategoryId == id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return category;
        }
    }
}
