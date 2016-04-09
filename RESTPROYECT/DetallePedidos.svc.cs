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
    public class DetallePedidos : IDetallePedidos
    {
        private DetalleDetallePedidoDAO dao = new DetalleDetallePedidoDAO();

        public DetallePedido CrearDetallePedido(DetallePedido DetallePedidoACrear)
        {
            return dao.Crear(DetallePedidoACrear);
        }

        public DetallePedido ObtenerDetallePedido(string idDetallePedidotmp)
        {
            int idDetallePedido = Int32.Parse(idDetallePedidotmp);
            return dao.Obtener(idDetallePedido);
        }

        public DetallePedido ModificarDetallePedido(DetallePedido DetallePedidoAModificar)
        {
            return dao.Modificar(DetallePedidoAModificar);
        }

        public void EliminarDetallePedido(DetallePedido DetallePedidoAEliminar)
        {
            dao.Eliminar(DetallePedidoAEliminar);
        }

        public List<DetallePedido> ListarADetallePedidos()
        {
            return dao.listar();
        }
    }
}
