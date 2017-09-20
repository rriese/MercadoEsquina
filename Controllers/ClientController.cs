using MercadoEsquina.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MercadoEsquina.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext _context;
        public ClientController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Client
        public ActionResult Clients()
        {
            var client = _context.Clients.ToList();
            //client.Clients.Add(new Client(1001, "Rafael", "5656565", new DateTime(1998, 3, 13)));
            //client.Clients.Add(new Client(1002, "Matheus", "1113365", new DateTime(1998, 1, 19)));
            //client.Clients.Add(new Client(1003, "Johny", "5656565", new DateTime(1997, 6, 23)));
            return View(client);
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
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}