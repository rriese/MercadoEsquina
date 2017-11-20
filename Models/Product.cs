using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}