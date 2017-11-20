using MercadoEsquina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadoEsquina.ViewModels
{
    public class OrderFormViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Order Order { get; set; }
    }
}