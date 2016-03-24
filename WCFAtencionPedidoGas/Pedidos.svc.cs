using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAtencionPedidoGas.Dominio;
using WCFAtencionPedidoGas.Persistencia;

namespace WCFAtencionPedidoGas
{
    public class Pedidos : IPedidos
    {
        private PedidoDAO pedidoDAO = new PedidoDAO();

        public Pedido registrarPedido(Pedido pedidoARegistrar)
        {
            return pedidoDAO.Crear(pedidoARegistrar);
        }

        public Pedido anularPedido()
        {
            throw new NotImplementedException();
        }

        public Pedido actualizarPedido()
        {
            throw new NotImplementedException();
        }

        public List<Pedido> listarPedidos()
        {
            return pedidoDAO.ListarPedidos();
        }

        public List<Pedido> listarPedidosClientes(int idCliente)
        {
            return pedidoDAO.ListarPedidosCliente(idCliente);
        }
               
    }
}
