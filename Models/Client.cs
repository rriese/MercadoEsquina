using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MercadoEsquina.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public Client()
        {
        }
        public Client(int id, string name, string cpf, DateTime birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.Cpf = cpf;
            this.BirthDate = birthDate;
        }
    }
}