using MercadoEsquina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var product = _context.Products.ToList();
            return View(product);
        }

        public ActionResult New()
        {
            return View("Form", new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product produto)
        {
            if (ModelState.IsValid)
            {
                if (produto.Id == 0)
                {
                    _context.Products.Add(produto);
                }
                else
                {
                    var produtosInDb = _context.Products.Single(c => c.Id == produto.Id);

                    produtosInDb.Description = produto.Description;
                    produtosInDb.Value = produto.Value;
                    produtosInDb.Quantity = produto.Quantity;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", produto);
            }
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);

            if (product != null)
            {
                return View("Form", product);
            }
            else {
                return HttpNotFound();
            }
        }

        public ActionResult Remove(int id)
        {
            var product = _context.Products.Single(m => m.Id == id);

            if (product != null) _context.Products.Remove(product);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}