using MercadoEsquina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadoEsquina.ViewModels
{
    public class SupplierViewModel
    {
        public IEnumerable<Supplier> Suppliers { get; set; }
        public Supplier Supplier { get; set; }
        public bool HasPermission { get; set; }
        public string Title
        {
            get
            {
                if (Supplier != null && Supplier.Id != 0)
                {
                    return "Edição de Fornecedor";
                } else
                {
                    return "Cadastro de Fornecedor";
                }
            }
        }
    }
}