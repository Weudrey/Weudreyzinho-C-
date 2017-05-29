using System.Net;
using System.Web.Mvc;
using Model.Registers;
using Services.Registers;
using Services.Tables;

namespace WeudreYZukowski.Controllers
{
    public class ProductsController : Controller
    {
        private ProductServices productService = new ProductServices();
        private CategoryService categoryService = new CategoryService();
        private SupplierService supplierService = new SupplierService();

        #region [ Index ]
        // GET: Products
        public ActionResult Index()
        {
            return View(productService.GetByName());
        }
        #endregion

        #region [ Details ]
        public ActionResult Details(long? id)
        {
            return ProductById(id);
        }
        #endregion

        #region [ Delete ]
        public ActionResult Delete(long? id)
        {
            return ProductById(id);
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Product product = productService.DeleteByID(id);
                TempData["Message"] = "Produto	" + product.Name.ToUpper()
                                + "	foi	removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion
        #region [ Edit ]
        public ActionResult Edit(long? id)
        {
            PopularViewBag(productService.GetByID((long)id));
            return ProductById(id);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            return SaveProduct(product);
        }
        #endregion

        #region [ Create ]
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }        [HttpPost]
        public ActionResult Create(Product product)
        {
            return SaveProduct(product);
        }
        #endregion

        #region [ Save ]
        private ActionResult SaveProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productService.Save(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }
        #endregion

        #region [ Uteis ]
        private ActionResult ProductById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Product product = productService.GetByID((long)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        private void PopularViewBag(Product product = null)
        {
            if (product == null)
            {
                ViewBag.CategoryId = new SelectList(categoryService.GetByName(),"CategoryId", "Name");
                ViewBag.SupplierId = new SelectList(supplierService.SuppliersByName(),"SupplierId", "Name");
            }
            else
            {
                ViewBag.CategoryId = new SelectList(categoryService.GetByName(), "CategoryId", "Name", product.CategoryId);
                ViewBag.SupplierId = new SelectList(supplierService.SuppliersByName(),"SupplierId", "Name", product.SupplierId);
            }
        }


        #endregion
    }
}
