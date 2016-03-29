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
    public interface IPedidos
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "pedidos", ResponseFormat = WebMessageFormat.Json)]
        Pedido CrearPedido(Pedido PedidoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "pedidos/{idPedido}", ResponseFormat = WebMessageFormat.Json)]
        Pedido ObtenerPedido(string idPedido);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "pedidos", ResponseFormat = WebMessageFormat.Json)]
        Pedido ModificarPedido(Pedido PedidoAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "pedidos/{idPedido}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarPedido(Pedido PedidoAEliminar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "pedidos", ResponseFormat = WebMessageFormat.Json)]
        List<Pedido> ListarAPedidos();
    }
}
