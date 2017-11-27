using MercadoEsquina.Models;
using MercadoEsquina.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            var client = new ClientViewModel()
            {
                Clients = _context.Clients.ToList(),
                HasPermission = User.IsInRole(Util.CanManageRole)
            };
            return View(client);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClientViewModel viewModel)
        {
            Client client = viewModel.Client;

            if (ModelState.IsValid)
            {
                if (client.Id == 0)
                {
                    _context.Clients.Add(client);
                }
                else
                {
                    var clientsInDb = _context.Clients.Single(c => c.Id == client.Id);

                    clientsInDb.Name = client.Name;
                    clientsInDb.BirthDate = client.BirthDate;
                    clientsInDb.Cpf = client.Cpf;
                    clientsInDb.PhoneNumber = client.PhoneNumber;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                return View("Form", client);
            }
        }

        public ActionResult Remove(int id)
        {
            if (User.IsInRole(Util.CanManageRole))
            {
                var client = _context.Clients.Single(m => m.Id == id);

                if (client != null) _context.Clients.Remove(client);

                _context.SaveChanges();

                return RedirectToAction("Index");
            } else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        public ActionResult Edit(int id)
        {
            if (User.IsInRole(Util.CanManageRole))
            {
                var client = new ClientViewModel()
                {
                    Client = _context.Clients.SingleOrDefault(c => c.Id == id)
                };

                if (client.Client != null)
                {
                    return View("Form", client);
                }
                else {
                    return HttpNotFound();
                }
            } else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        public ActionResult New()
        {
            if (User.IsInRole(Util.CanManageRole))
            {
                var client = new ClientViewModel()
                {
                    Client = new Client()
                };
                return View("Form", client);
            } else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }
    }
}