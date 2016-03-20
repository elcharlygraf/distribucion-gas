using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFAtencionPedidoGas.Dominio;

namespace WCFAtencionPedidoGas.Persistencia
{
    public class DetallePedidoDAO
    {

        private string cadenaConexion = "Data Source=(local);Initial Catalog=DB_PEDIDOS;Integrated Security=SSPI";

        public DetallePedido Crear(DetallePedido pedidoACrear)
        {
            DetallePedido pedidoCreado = null;
            string sql = "INSERT INTO t_detallPedido VALUES (@idPedido,@idProducto,@cantidad,@precioUnitario)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idPedido", pedidoACrear.idPedido));
                    comando.Parameters.Add(new SqlParameter("@idProducto", pedidoACrear.idProducto));
                    comando.Parameters.Add(new SqlParameter("@cantidad", pedidoACrear.cantidad));
                    comando.Parameters.Add(new SqlParameter("@precioUnitario", pedidoACrear.precioUnitario));

                    comando.ExecuteNonQuery();
                }
            }
            return pedidoCreado;
        }
    }
}