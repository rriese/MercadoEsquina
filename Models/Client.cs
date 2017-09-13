using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadoEsquina.Models
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cpf { get; set; }
        public DateTime birthDate { get; set; }

        public Client()
        {
        }
        public Client(int id, string name, string cpf, DateTime birthDate)
        {
            this.id = id;
            this.name = name;
            this.cpf = cpf;
            this.birthDate = birthDate;
        }
    }
}