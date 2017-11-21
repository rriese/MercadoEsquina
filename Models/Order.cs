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
        [Required]
        [Display(Name = "Cliente")]
        public Client Client { get; set; }
        [Required]
        [Display(Name = "Funcionário")]
        public Employee Employee { get; set; }
        public IList<OrderItem> Items { get; set; }

        public Order()
        {
        }

        public Order(int id, DateTime orderDate, Client client, Employee employee)
        {
            this.Id = id;
            this.OrderDate = orderDate;
            this.Client = client;
            this.Employee = employee;
        }

    }
}