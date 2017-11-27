using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MercadoEsquina.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Cnpj")]
        public string Cnpj { get; set; }
        [Required]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        public Supplier() {}

        public Supplier(string name, string cnpj, string address)
        {
            this.Name = name;
            this.Cnpj = cnpj;
            this.Address = address;
        }

    }
}