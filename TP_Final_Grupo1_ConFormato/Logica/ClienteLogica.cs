using Datos; 
using Entidades;
using System.Collections.Generic;

namespace Logica
{
    public class ClienteLogica
    {
        private ClienteConsulta clienteConsulta;

        public ClienteLogica()
        {
            clienteConsulta = new ClienteConsulta();
        }

        public List<Cliente> BuscarClientePorRazonSocial(string razonSocial)
        {
            
            return clienteConsulta.BuscarPorRazonSocial(razonSocial);
        }

    }
}
