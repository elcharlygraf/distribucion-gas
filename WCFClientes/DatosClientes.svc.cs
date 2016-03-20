using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFClientes.Dominio;
using WCFClientes.Persistencia;

namespace WCFClientes
{
    public class DatosClientes : IDatosClientes
    {
        private DatosClienteDAO clienteDAO = new DatosClienteDAO();

        public DatosCliente CrearCliente(DatosCliente clienteACrear)
        {
            return clienteDAO.Crear(clienteACrear);
        }

        public DatosCliente ObtenerDatosCliente(int idCliente)
        {
            return clienteDAO.ObtenerDatos(idCliente);
        }

    }
}
