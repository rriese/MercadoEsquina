using MercadoEsquina.Models;
using MercadoEsquina.ViewModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;

namespace MercadoEsquina.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var product = new ProductViewModel()
            {
                Products = _context.Products.Include("Supplier").ToList(),
                HasPermission = User.IsInRole(Util.CanManageRole)
            };

            /*foreach (var produto in product.Products)
            {
                produto.Supplier = _context.Suppliers.Single(c => c.Id == produto.SupplierId);
            }*/
            return View(product);
        }

        public ActionResult New()
        {
            if (User.IsInRole(Util.CanManageRole))
            {
                var product = new ProductViewModel()
                {
                    Product = new Product(),
                    Suppliers = _context.Suppliers.ToList()
                };

                return View("Form", product);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProductViewModel viewModel)
        {
            Product product = viewModel.Product;

            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                {
                    _context.Products.Add(product);
                }
                else
                {
                    var productsInDb = _context.Products.Single(c => c.Id == product.Id);

                    productsInDb.Description = product.Description;
                    productsInDb.Value = product.Value;
                    productsInDb.Quantity = product.Quantity;
                    productsInDb.Supplier = product.Supplier;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", product);
            }
        }

        public ActionResult Edit(int id)
        {
            if (User.IsInRole(Util.CanManageRole))
            {
                var product = new ProductViewModel()
                {
                    Product = _context.Products.SingleOrDefault(c => c.Id == id)
                };

                if (product.Product != null)
                {
                    return View("Form", product);
                }
                else {
                    return HttpNotFound();
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        public ActionResult Remove(int id)
        {
            if (User.IsInRole(Util.CanManageRole))
            {
                var product = _context.Products.Single(m => m.Id == id);

                if (product != null) _context.Products.Remove(product);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }
    }
}