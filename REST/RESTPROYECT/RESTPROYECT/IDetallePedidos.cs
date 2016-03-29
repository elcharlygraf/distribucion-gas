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
    public interface IDetallePedidos
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "detalle/pedidos", ResponseFormat = WebMessageFormat.Json)]
        DetallePedido CrearDetallePedido(DetallePedido DetallePedidoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "detalle/pedidos/{idDetallePedido}", ResponseFormat = WebMessageFormat.Json)]
        DetallePedido ObtenerDetallePedido(string idDetallePedido);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "detalle/pedidos", ResponseFormat = WebMessageFormat.Json)]
        DetallePedido ModificarDetallePedido(DetallePedido DetallePedidoAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "detalle/pedidos", ResponseFormat = WebMessageFormat.Json)]
        void EliminarDetallePedido(DetallePedido DetallePedidoAEliminar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "detalle/pedidos", ResponseFormat = WebMessageFormat.Json)]
        List<DetallePedido> ListarADetallePedidos();
    }
}
