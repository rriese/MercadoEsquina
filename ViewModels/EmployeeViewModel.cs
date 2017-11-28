using MercadoEsquina.Models;
using System.Collections.Generic;

namespace MercadoEsquina.ViewModels
{
    public class EmployeeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }

        public Employee Employee { get; set; }

        public bool HasPermission { get; set; }

        public string Title
        {
            get
            {
                if (Employee != null && Employee.Id != 0)
                    return "Edição de Funcionário";

                return "Cadastro de Funcionário";
            }
        }
    }
}