using RESTPROYECT.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RESTPROYECT.Persistencia
{
    public class DetalleDetallePedidoDAO
    {
        public DetallePedido Crear(DetallePedido DetallePedidoACrear)
        {
            DetallePedido DetallePedidoCreado = null;
            string sql = "INSERT INTO t_detallePedido VALUES (@idPedido, @idProducto, @cantidad, @cantidad)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idPedido", DetallePedidoACrear.idPedido));
                    com.Parameters.Add(new SqlParameter("@idProducto", DetallePedidoACrear.idProducto));
                    com.Parameters.Add(new SqlParameter("@cantidad", DetallePedidoACrear.cantidad));
                    com.Parameters.Add(new SqlParameter("@cantidad", DetallePedidoACrear.cantidad));
                    com.ExecuteNonQuery();
                }
            }
            DetallePedidoCreado = Obtener(DetallePedidoACrear.idDetallePedido);
            return DetallePedidoCreado;
        }

        public DetallePedido Obtener(int idDetallePedido)
        {
            DetallePedido DetallePedidoEncontrado = null;
            string sql = "SELECT * FROM t_detallePedido WHERE idDetallePedido=@idDetallePedido";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idDetallePedido", idDetallePedido));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            DetallePedidoEncontrado = new DetallePedido()
                            {
                                idPedido = (int)resultado["idPedido"],
                                idProducto = (int)resultado["idProducto"],
                                cantidad = (int)resultado["cantidad"],
                                precioUnitario = (decimal)resultado["precioUnitario"]
                            };
                        }
                    }
                }
            }
            return DetallePedidoEncontrado;
        }

        public DetallePedido Modificar(DetallePedido DetallePedidoAModificar)
        {
            DetallePedido DetallePedidoModificado = null;
            string sql = "UPDATE t_detallePedido SET idPedido=@idPedido, idProducto=@idProducto, cantidad=@cantidad, precioUnitario=@precioUnitario WHERE idDetallePedido=@idDetallePedido";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idDetallePedido", DetallePedidoAModificar.idDetallePedido));
                    com.Parameters.Add(new SqlParameter("@idPedido", DetallePedidoAModificar.idPedido));
                    com.Parameters.Add(new SqlParameter("@idProducto", DetallePedidoAModificar.idProducto));
                    com.Parameters.Add(new SqlParameter("@cantidad", DetallePedidoAModificar.cantidad));
                    com.Parameters.Add(new SqlParameter("@precioUnitario", DetallePedidoAModificar.precioUnitario));
                    com.ExecuteNonQuery();
                }
            }
            DetallePedidoModificado = Obtener(DetallePedidoAModificar.idDetallePedido);
            return DetallePedidoModificado;
        }

        public void Eliminar(DetallePedido DetallePedidoAEliminar)
        {
            string sql = "DELETE FROM t_detallePedido WHERE idDetallePedido=@idDetallePedido";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idDetallePedido", DetallePedidoAEliminar.idDetallePedido));
                    com.ExecuteNonQuery();
                }
            }
        }

        public List<DetallePedido> listar()
        {
            List<DetallePedido> DetallePedidosEncontrados = new List<DetallePedido>();
            DetallePedido DetallePedidosEncontrado = default(DetallePedido);
            string sql = "SELECT * FROM t_detallePedido";
            //string sql = "select t1.idDetallePedido, t1.idPedido, t2.producto, t1.cantidad, t1.precioUnitario from t_detallePedido t1, t_productos t2 where t1.idProducto = t2.idProducto";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            DetallePedidosEncontrado = new DetallePedido()
                            {
                                idPedido = (int)resultado["idPedido"],
                                idProducto = (int)resultado["idProducto"],
                                cantidad = (int)resultado["cantidad"],
                                precioUnitario = (decimal)resultado["precioUnitario"]
                            };
                            DetallePedidosEncontrados.Add(DetallePedidosEncontrado);
                        }
                    }
                }
            }
            return DetallePedidosEncontrados;
        }

    }
}