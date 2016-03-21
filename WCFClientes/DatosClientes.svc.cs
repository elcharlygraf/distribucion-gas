using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFClientes.Dominio;
using WCFClientes.Persistencia;

namespace WCFClientes
{
    public class DatosClientes : IDatosClientes
    {
        private DatosClienteDAO clienteDAO = new DatosClienteDAO();
        
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "crearcliente")]
        public DatosCliente CrearCliente(DatosCliente clienteACrear)
        {
            return clienteDAO.Crear(clienteACrear);
        }

       [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "obtenercliente/{idCliente}")
           
        ]
        public DatosCliente ObtenerDatosCliente(string idCliente)
        {
            return clienteDAO.ObtenerDatos(idCliente);
        }

    }
}
