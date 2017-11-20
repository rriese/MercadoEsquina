using MercadoEsquina.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MercadoEsquina.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext _context;
        public ClientsController()
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var client = _context.Clients.ToList();
            return View(client);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Client cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Id == 0)
                {
                    _context.Clients.Add(cliente);
                }
                else
                {
                    var clientsInDb = _context.Clients.Single(c => c.Id == cliente.Id);

                    clientsInDb.Name = cliente.Name;
                    clientsInDb.BirthDate = cliente.BirthDate;
                    clientsInDb.Cpf = cliente.Cpf;
                    clientsInDb.PhoneNumber = cliente.PhoneNumber;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                return View("Form", cliente);
            }
        }

        public ActionResult Remove(int id)
        {
            var client = _context.Clients.Single(m => m.Id == id);

            if (client != null) _context.Clients.Remove(client);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (client != null)
            {
                return View("Form", client);
            }
            else {
                return HttpNotFound();
            }
        }

        public ActionResult New()
        {
            return View("Form", new Client());
        }
    }
}