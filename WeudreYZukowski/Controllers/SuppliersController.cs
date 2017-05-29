using System.Net;
using System.Web.Mvc;
using Model.Registers;
using Services.Registers;

namespace WeudreYZukowski.Controllers
{
    public class SuppliersController : Controller
    {
        private SupplierService supplierService = new SupplierService();

        #region [ Actions ]

        #region [ Index ]

        // GET: Supplier
        public ActionResult Index()
        {
            return View(supplierService.SuppliersByName());
        }

        #endregion [ Index ]

        #region [ CREATE ]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
           return SaveSupplier(supplier);
        }

        #endregion [ CREATE ]

        #region [ Edit ]

        public ActionResult Edit(long? id)
        {
            return SupplierById(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            return SaveSupplier(supplier);
        }

        #endregion

        #region [ Delete ]

        public ActionResult Delete(long? id)
        {
            return SupplierById(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                Supplier supplier = supplierService.DeleteSupplier(id);
                TempData["Message"] = "Produto	" + supplier.Name.ToUpper()
                                + "	foi	removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        #endregion

        #region [ Details ]

        public ActionResult Details(long? id)
        {
            return SupplierById(id);
        }

        #endregion

        #region [ Save ]
        private ActionResult SaveSupplier(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    supplierService.SaveSupplier(supplier);
                    return RedirectToAction("Index");
                }
                return View(supplier);
            }
            catch
            {
                return View(supplier);
            }
        }
        #endregion

        private ActionResult SupplierById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Supplier supplier = supplierService.SupplierById((long)id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        #endregion [ Actions ]

    }
}