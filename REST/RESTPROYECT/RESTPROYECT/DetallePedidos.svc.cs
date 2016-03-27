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

        public DetallePedido CrearDetallePedido(DetallePedidos DetallePedidoACrear)
        {
            return dao.Crear(DetallePedidoACrear);
        }

        public DetallePedido ObtenerDetallePedido(string idDetallePedido)
        {
            return dao.Obtener(idDetallePedido);
        }

        public DetallePedido ModificarDetallePedido(DetallePedidos DetallePedidoAModificar)
        {
            return dao.Modificar(DetallePedidoAModificar);
        }

        public void EliminarDetallePedido(string idDetallePedido)
        {
            dao.Eliminar(idDetallePedido);
        }

        public List<DetallePedido> ListarADetallePedidos()
        {
            return dao.listar();
        }
    }
}
