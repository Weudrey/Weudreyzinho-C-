using Model.Registers;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percistence.DAL.Registers
{
    public class SupplierDAL
    {
        private EFContexts context = new EFContexts();
        public IEnumerable<Supplier> SuppliersByName()
        {
            return context.Suppliers.OrderBy(b => b.Name);
        }
        public Supplier SupplierById(long? id)
        {
            return context.Suppliers.Where(p => p.SupplierID == id).First();
        }
        public void SaveSupplier(Supplier supplier)
        {
            if (supplier.SupplierID == null)
            {
                context.Suppliers.Add(supplier);
            }
            else
            {
                context.Entry(supplier).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Supplier DeleteSupplier(long id)
        {
            Supplier supplier = SupplierById(id);
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            return supplier;
        }
    }
}
