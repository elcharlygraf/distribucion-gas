using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAtencionPedidoGas.Dominio;

namespace WCFAtencionPedidoGas
{
    [ServiceContract]
    public interface IPedidos
    {
        [OperationContract]
        Pedido registrarPedido(Pedido pedidoARegistrar);

        [OperationContract]
        Pedido anularPedido();

        [OperationContract]
        Pedido actualizarPedido();

        [OperationContract]
        List<Pedido> listarPedidos();

        [OperationContract]
        List<Pedido> listarPedidosClientes(int idCliente);

    }
}
