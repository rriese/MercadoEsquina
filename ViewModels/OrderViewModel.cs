using MercadoEsquina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadoEsquina.ViewModels
{
    public class OrderViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public Order Order { get; set; }
    }
}