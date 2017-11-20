using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MercadoEsquina.Models
{
    public class Employee
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
        [Display(Name = "Função")]
        public string Function { get; set; }
        [Required]
        [Display(Name = "Salário")]
        public double Salary { get; set; }
        [Required]
        [Display(Name = "Número de Telefone")]
        public string PhoneNumber { get; set; }

        public Employee()
        {
        }

        public Employee(int Id, string Name, string Cpf, DateTime BirthDate, string Function, double Salary, string PhoneNumber)
        {
            this.Id = Id;
            this.Name = Name;
            this.Cpf = Cpf;
            this.BirthDate = BirthDate;
            this.Function = Function;
            this.Salary = Salary;
            this.PhoneNumber = PhoneNumber;
        }

    }
}