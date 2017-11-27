using MercadoEsquina.Models;
using MercadoEsquina.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MercadoEsquina.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var employee = new EmployeeViewModel()
            {
                Employees = _context.Employees.ToList(),
                HasPermission = User.IsInRole(Util.CanManageRole)
            };

            return View(employee);
        }

        public ActionResult New()
        {
            if (User.IsInRole(Util.CanManageRole))
            {
                var employee = new EmployeeViewModel() {

                    Employee = new Employee()
                };

                return View("Form", employee);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EmployeeViewModel viewModel)
        {
            Employee employee = viewModel.Employee;

            if (ModelState.IsValid)
            {
                if (employee.Id == 0)
                {
                    _context.Employees.Add(employee);
                }
                else
                {
                    var employeesInDb = _context.Employees.Single(c => c.Id == employee.Id);

                    employeesInDb.Name = employee.Name;
                    employeesInDb.BirthDate = employee.BirthDate;
                    employeesInDb.Cpf = employee.Cpf;
                    employeesInDb.Function = employee.Function;
                    employeesInDb.Salary = employee.Salary;
                    employeesInDb.PhoneNumber = employee.PhoneNumber;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", employee);
            }
        }

        public ActionResult Edit(int id)
        {
            if (User.IsInRole(Util.CanManageRole))
            {
                var employee = new EmployeeViewModel()
                {
                    Employee = _context.Employees.SingleOrDefault(c => c.Id == id)
                };
                if (employee.Employee != null)
                {
                    return View("Form", employee);
                }

                return HttpNotFound();
            } else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        public ActionResult Remove(int id)
        {
            if (User.IsInRole(Util.CanManageRole))
            {
                var employee = _context.Employees.Single(m => m.Id == id);

                if (employee != null) _context.Employees.Remove(employee);

                _context.SaveChanges();

                return RedirectToAction("Index");
            } else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}