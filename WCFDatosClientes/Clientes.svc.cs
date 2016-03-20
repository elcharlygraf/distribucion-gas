using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFDatosClientes.Dominio;
using WCFDatosClientes.Persistencia;

namespace WCFDatosClientes
{
    public class Clientes : IClientes
    {
        private ClienteDAO clienteDAO = new ClienteDAO();

        public Cliente CrearCliente(Cliente clienteACrear)
        {
            return clienteDAO.Crear(clienteACrear);
        }
                
        public Cliente ObtenerCliente(int idCliente)
        {
            return clienteDAO.Obtener(idCliente);
        }
    }
}
