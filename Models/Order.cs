using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MercadoEsquina.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Data Venda")]
        public DateTime? OrderDate { get; set; }
        [Display(Name = "Cliente")]
        public Client Client { get; set; }
        public bool isFinalized { get; set; }
     
        public Order()
        {
        }

        public Order(int id, DateTime orderDate, Client client, bool isFinalized)
        {
            this.Id = id;
            this.OrderDate = orderDate;
            this.Client = client;
            this.isFinalized = isFinalized;
        }
    }
}