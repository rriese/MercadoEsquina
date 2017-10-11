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
        public ActionResult Index()
        {
            var client = _context.Clients.ToList();
            return View(client);
        }
        [HttpPost]
        public ActionResult Save(Client cliente)
        {
            if (cliente.id == 0)
            {
                _context.Clients.Add(cliente);
            } else
            {
                var clientsInDb = _context.Clients.Single(c => c.id == cliente.id);

                clientsInDb.name = cliente.name;
                clientsInDb.birthDate = cliente.birthDate;
                clientsInDb.cpf = cliente.cpf;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var client = _context.Clients.Single(m => m.id == id);

            if (client != null) _context.Clients.Remove(client);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            foreach (var client in _context.Clients.ToList())
            {
                if (client.id == id)
                {
                    return View(client);
                }
            }
            return HttpNotFound();
        }

        public ActionResult New()
        {
            return View("Edit");
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}