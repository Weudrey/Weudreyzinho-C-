using Model.Registers;
using Percistence.DAL.Registers;
using System.Collections.Generic;

namespace Services.Registers
{
    public class SupplierService
    {
        private SupplierDAL supplierDAL = new SupplierDAL();
        public IEnumerable<Supplier> SuppliersByName()
        {
            return supplierDAL.SuppliersByName();
        }

        public Supplier SupplierById(long id)
        {
            return supplierDAL.SupplierById(id);
        }
        public void SaveSupplier(Supplier supplier)
        {
            supplierDAL.SaveSupplier(supplier);
        }
        public Supplier DeleteSupplier(long id)
        {
            return supplierDAL.DeleteSupplier(id);
        }
    }
}
