using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTPROYECT.Dominio;
using RESTPROYECT.Persistencia;

namespace RESTPROYECT
{
    public class Pedidos : IPedidos
    {
        private PedidoDAO dao = new PedidoDAO();

        public Pedido CrearPedido(Pedidos PedidoACrear)
        {
            return dao.Crear(PedidoACrear);
        }

        public Pedido ObtenerPedido(string idPedido)
        {
            return dao.Obtener(idPedido);
        }

        public Pedido ModificarPedido(Pedidos PedidoAModificar)
        {
            return dao.Modificar(PedidoAModificar);
        }

        public void EliminarPedido(string idPedido)
        {
            dao.Eliminar(idPedido);
        }

        public List<Pedido> ListarAPedidos()
        {
            return dao.listar();
        }
    }
}
