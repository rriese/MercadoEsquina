using MercadoEsquina.Models;
using MercadoEsquina.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercadoEsquina.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context;
        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        public ActionResult New()
        {
            var viewModel = new OrderFormViewModel()
            {
                Clients = _context.Clients.ToList(),
                Employees = _context.Employees.ToList(),
                Products = _context.Products.ToList(),
                Order = new Order()
            };

            return View("Form", viewModel);
        }
    }
}