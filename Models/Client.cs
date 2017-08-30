using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadoEsquina.Models
{
    public class Client
    {
        //BD TEMPORÁRIO
        public List<Client> Clients { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string cpf { get; set; }
        public DateTime birthDate { get; set; }

        public Client()
        {
            Clients = new List<Client>();
        }
        public Client(int id, string name, string cpf, DateTime birthDate) : base()
        {
            this.id = id;
            this.name = name;
            this.cpf = cpf;
            this.birthDate = birthDate;
        }
    }
}