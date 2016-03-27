using RESTPROYECT.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTPROYECT
{
    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "clientes", ResponseFormat = WebMessageFormat.Json)]
        Cliente CrearCliente(Clientes clienteACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "clientes/{idCliente}", ResponseFormat = WebMessageFormat.Json)]
        Cliente ObtenerCliente(string idCliente);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "clientes", ResponseFormat = WebMessageFormat.Json)]
        Cliente ModificarCliente(Clientes clienteAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "clientes/{idCliente}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarCliente(string idCliente);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "clientes", ResponseFormat = WebMessageFormat.Json)]
        List<Cliente> ListarAClientes();
    }
}
