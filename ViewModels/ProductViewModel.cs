using MercadoEsquina.Models;
using System.Collections.Generic;

namespace MercadoEsquina.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }

        public Product Product { get; set; }

        public bool HasPermission { get; set; }

        public string Title
        {
            get
            {
                if (Product != null && Product.Id != 0)
                    return "Edição de Produto";

                return "Cadastro de Produto";
            }
        }
    }
}