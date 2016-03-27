using RESTPROYECT.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RESTPROYECT
{
    [ServiceContract]
    public interface IPedidos
    {
        [OperationContract]
        Pedido CrearPedido(Pedidos PedidoACrear);

        [OperationContract]
        Pedido ObtenerPedido(string idPedido);

        [OperationContract]
        Pedido ModificarPedido(Pedidos PedidoAModificar);

        [OperationContract]
        void EliminarPedido(string idPedido);

        [OperationContract]
        List<Pedido> ListarAPedidos();
    }
}
