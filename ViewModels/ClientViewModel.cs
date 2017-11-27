using MercadoEsquina.Models;
using System.Collections.Generic;

namespace MercadoEsquina.ViewModels
{
    public class ClientViewModel
    {
        public IEnumerable<Client> Clients { get; set; }

        public Client Client { get; set; }

        public bool HasPermission { get; set; }

        public string Title
        {
            get
            {
                if (Client != null && Client.Id != 0)
                    return "Edição de Cliente";

                return "Cadastro de Cliente";
            }
        }
    }
}