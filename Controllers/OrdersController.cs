using MercadoEsquina.Models;
using MercadoEsquina.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

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
            var orders = _context.Orders.Include(c => c.Client).ToList();
            return View(orders);
        }

        public ActionResult New()
        {
            var viewModel = new OrderViewModel()
            {
                Clients = _context.Clients.ToList(),
                Order = new Order()
            };

            return View("Form", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(OrderViewModel viewModel)
        {
            Order order = viewModel.Order;
            order.Client = _context.Clients.Single(c => c.Id == order.Client.Id);

            _context.Orders.Add(order);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}