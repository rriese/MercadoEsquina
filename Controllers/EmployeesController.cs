using MercadoEsquina.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
            var employee = _context.Employees.ToList();
            return View(employee);
        }

        public ActionResult New()
        {
            var employee = new Employee();
            return View("Form", employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Employee funcionario)
        {
            if (ModelState.IsValid)
            {
                if (funcionario.Id == 0)
                {
                    _context.Employees.Add(funcionario);
                }
                else
                {
                    var employeesInDb = _context.Employees.Single(c => c.Id == funcionario.Id);

                    employeesInDb.Name = funcionario.Name;
                    employeesInDb.BirthDate = funcionario.BirthDate;
                    employeesInDb.Cpf = funcionario.Cpf;
                    employeesInDb.Function = funcionario.Function;
                    employeesInDb.Salary = funcionario.Salary;
                    employeesInDb.PhoneNumber = funcionario.PhoneNumber;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", funcionario);
            }
        }

        public ActionResult Edit(int id)
        {
            foreach (var employee in _context.Employees.ToList())
            {
                if (employee.Id == id)
                {
                    return View("Form", employee);
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