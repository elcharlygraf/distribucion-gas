using RESTPROYECT.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RESTPROYECT.Persistencia
{
    public class PedidoDAO
    {
        public Pedido Crear(Pedido PedidoACrear)
        {
            Pedido PedidoCreado = null;
            string sql = "INSERT INTO t_pedidos VALUES (@idCliente, @montoTotal, @idEstado, @fechaPedido)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idCliente", PedidoACrear.idCliente));
                    com.Parameters.Add(new SqlParameter("@montoTotal", PedidoACrear.montoTotal));
                    com.Parameters.Add(new SqlParameter("@idEstado", PedidoACrear.idEstado));
                    com.Parameters.Add(new SqlParameter("@fechaPedido", PedidoACrear.fechaPedido));
                    com.ExecuteNonQuery();
                }
            }
            PedidoCreado = Obtener(PedidoACrear.idPedido);
            return PedidoCreado;
        }

        public Pedido Obtener(int idPedido)
        {
            Pedido PedidoEncontrado = null;
            string sql = "SELECT * FROM t_pedidos WHERE idPedido=@idPedido";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idPedido", idPedido));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            PedidoEncontrado = new Pedido()
                            {
                                idCliente = (int)resultado["idCliente"],
                                montoTotal = (decimal)resultado["montoTotal"],
                                idEstado = (int)resultado["idEstado"],
                                fechaPedido = (string)resultado["fechaPedido"]
                            };
                        }
                    }
                }
            }
            return PedidoEncontrado;
        }

        public Pedido Modificar(Pedido PedidoAModificar)
        {
            Pedido PedidoModificado = null;
            string sql = "UPDATE t_pedidos SET idCliente=@idCliente, montoTotal=@montoTotal, idEstado=@idEstado, fechaPedido=@fechaPedido WHERE idPedido=@idPedido";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idCliente", PedidoAModificar.idCliente));
                    com.Parameters.Add(new SqlParameter("@montoTotal", PedidoAModificar.montoTotal));
                    com.Parameters.Add(new SqlParameter("@idEstado", PedidoAModificar.idEstado));
                    com.Parameters.Add(new SqlParameter("@fechaPedido", PedidoAModificar.fechaPedido));
                    com.ExecuteNonQuery();
                }
            }
            PedidoModificado = Obtener(PedidoAModificar.idPedido);
            return PedidoModificado;
        }

        public void Eliminar(Pedido PedidoAEliminar)
        {
            string sql = "DELETE FROM t_pedidos WHERE idPedido=@idPedido";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idPedido", PedidoAEliminar.idPedido));
                    com.ExecuteNonQuery();
                }
            }
        }

        public List<Pedido> listar()
        {
            List<Pedido> pedidosEncontrados = new List<Pedido>();
            Pedido PedidoEncontrado = default(Pedido);
            string sql = "SELECT * FROM t_pedidos";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            PedidoEncontrado = new Pedido()
                            {
                                idCliente = (int)resultado["idCliente"],
                                montoTotal = (decimal)resultado["montoTotal"],
                                idEstado = (int)resultado["idEstado"],
                                fechaPedido = (string)resultado["fechaPedido"]
                            };
                            pedidosEncontrados.Add(PedidoEncontrado);
                        }
                    }
                }
            }
            return pedidosEncontrados;
        }
        

    }
}