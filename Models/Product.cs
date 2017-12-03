using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MercadoEsquina.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Valor")]
        public double Value { get; set; }
        [Required]
        [Display(Name = "Quantidade")]
        public int Quantity { get; set; }
        public Supplier Supplier { get; set; }
        [Display(Name = "Fornecedor")]
        public int SupplierId { get; set; }

        public Product() { }

        public Product(int Id, string Description, double Value, int Quantity, Supplier Supplier)
        {
            this.Id = Id;
            this.Description = Description;
            this.Value = Value;
            this.Quantity = Quantity;
            this.Supplier = Supplier;
        }
    }
}