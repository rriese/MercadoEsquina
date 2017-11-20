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
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateTime? BirthDate { get; set; }
        [Required]
        [Display(Name = "Número de Telefone")]
        public String PhoneNumber { get; set; }

        public Client()
        {
        }
        public Client(int id, string name, string cpf, DateTime birthDate, string phoneNumber)
        {
            this.Id = id;
            this.Name = name;
            this.Cpf = cpf;
            this.BirthDate = birthDate;
            this.PhoneNumber = phoneNumber;
        }
    }
}