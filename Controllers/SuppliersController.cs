using MercadoEsquina.Models;
using MercadoEsquina.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace MercadoEsquina.Controllers
{
    public class SuppliersController : Controller
    {
        private ApplicationDbContext _context;
        public SuppliersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var viewModel = new SupplierViewModel()
            {
                Suppliers = _context.Suppliers.ToList(),
                HasPermission = User.IsInRole(Util.CanManageRole)
            };
            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new SupplierViewModel()
            {
                Supplier = new Supplier()
            };

            return View("Form", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SupplierViewModel viewModel)
        {
            Supplier supplier = viewModel.Supplier;

            if (ModelState.IsValid)
            {
                if (supplier.Id == 0)
                {
                    _context.Suppliers.Add(supplier);
                }
                else
                {
                    var suppliersInDb = _context.Suppliers.Single(c => c.Id == supplier.Id);

                    suppliersInDb.Name = supplier.Name;
                    suppliersInDb.Cnpj = supplier.Cnpj;
                    suppliersInDb.Address = supplier.Address;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", supplier);
            }
        }
    }
}