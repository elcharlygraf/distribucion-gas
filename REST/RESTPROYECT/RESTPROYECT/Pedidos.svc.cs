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

        public Pedido CrearPedido(Pedido PedidoACrear)
        {
            return dao.Crear(PedidoACrear);
        }

        public Pedido ObtenerPedido(string idPedidotmp)
        {
            int idPedido = Int32.Parse(idPedidotmp);
            return dao.Obtener(idPedido);
        }

        public Pedido ModificarPedido(Pedido PedidoAModificar)
        {
            return dao.Modificar(PedidoAModificar);
        }

        public void EliminarPedido(Pedido PedidoAEliminar)
        {
            dao.Eliminar(PedidoAEliminar);
        }

        public List<Pedido> ListarAPedidos()
        {
            return dao.listar();
        }
    }
}
