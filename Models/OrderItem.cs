using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadoEsquina.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int id, Order order, Product product)
        {
            this.Id = id;
            this.Order = order;
            this.Product = product;
        }
    }
}