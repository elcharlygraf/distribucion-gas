using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTPROYECT.Dominio;
using RESTPROYECT.Persistencia;
using RESTPROYECT.Messaging;

namespace RESTPROYECT
{
    public class Pedidos : IPedidos
    {
        private PedidoDAO dao = new PedidoDAO();
        private DetalleDetallePedidoDAO daoDetalle = new DetalleDetallePedidoDAO();

        public Pedido CrearPedido(Pedido PedidoACrear)
        {
            Producto productoPrecioActualizar = new Producto();
            productoPrecioActualizar.idProducto = PedidoACrear.detallePedido.idProducto;
            productoPrecioActualizar.flgActualizarPrecio = true;
            decimal dtot = (decimal)((decimal)PedidoACrear.detallePedido.precioUnitario);
            productoPrecioActualizar.precio = dtot;
            ProductoMessaging mensajeria = new ProductoMessaging();
            mensajeria.enviarPrecioVerificacion(productoPrecioActualizar);

            Pedido pedidoRegistrado = dao.Crear(PedidoACrear);
            DetallePedido detalleDominio = new DetallePedido();
            detalleDominio.idPedido = pedidoRegistrado.idPedido;
            detalleDominio.idProducto = PedidoACrear.detallePedido.idProducto;
            detalleDominio.precioUnitario = PedidoACrear.detallePedido.precioUnitario;
            DetallePedido detalleRegistrado = daoDetalle.Crear(detalleDominio);
            pedidoRegistrado.detallePedido = detalleRegistrado;
            return pedidoRegistrado;
        }

        public Pedido ObtenerPedido(string idClientetmp)
        {
            int idCliente = Int32.Parse(idClientetmp);
            return dao.Obtener(idCliente);
        }

        public Pedido ModificarPedido(Pedido PedidoAModificar)
        {
            return dao.Modificar(PedidoAModificar);
        }

        public void EliminarPedido(Pedido PedidoAEliminar)
        {
            dao.Eliminar(PedidoAEliminar);
        }

        public List<Pedido> ListarAPedidos(string idClientetmp)
        {
            int idCliente = Int32.Parse(idClientetmp);
            return dao.listar(idCliente);            
        }

        public List<Pedido> ListarAPedidos()
        {
            throw new NotImplementedException();
        }
    }
}
