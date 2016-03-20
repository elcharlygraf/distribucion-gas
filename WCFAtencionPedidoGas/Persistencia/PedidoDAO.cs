using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFAtencionPedidoGas.Dominio;

namespace WCFAtencionPedidoGas.Persistencia
{
    public class PedidoDAO
    {

         private string cadenaConexion = "Data Source=(local);Initial Catalog=DB_PEDIDOS;Integrated Security=SSPI";

        public Pedido Crear(Pedido pedidoACrear)
        {
            Pedido pedidoCreado = null;
            string sql = "INSERT INTO t_pedidos VALUES (@idCliente,@montoTotal,@idEstado,@fechaPedido)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idCliente", pedidoACrear.idCliente));
                    comando.Parameters.Add(new SqlParameter("@montoTotal", pedidoACrear.montoTotal));
                    comando.Parameters.Add(new SqlParameter("@idEstado", pedidoACrear.idEstado));
                    comando.Parameters.Add(new SqlParameter("@fechaPedido", pedidoACrear.fechaPedido));

                    comando.ExecuteNonQuery();
                }
            }
            return pedidoCreado;
        }

        public Pedido Actualizar(Pedido pedidoAModificar)
        {
            Pedido pedidoModificado = null;
            string sql = "UPDATE t_pedidos SET montoTotal=@montoTotal WHERE idPedido=@idPedido";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idPedido", pedidoAModificar.idPedido));
                    comando.Parameters.Add(new SqlParameter("@montoTotal", pedidoAModificar.montoTotal));
                    comando.ExecuteNonQuery();
                }
            }
            pedidoModificado = Obtener(pedidoAModificar.idPedido);
            return pedidoModificado;
        }

        public Pedido Obtener(int idPedido)
        {
            Pedido pedidoEncontrado = null;

            string sql = "SELECT * FROM t_pedidos WHERE idPedido=@idPedido";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idPedido", idPedido));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            pedidoEncontrado = new Pedido()
                            {
                                idPedido = (int)resultado["idPedido"],
                                idCliente = (int)resultado["idCliente"],
                                montoTotal = (decimal)resultado["montoTotal"],
                                idEstado = (int)resultado["idEstado"],
                                fechaPedido = (DateTime)resultado["fechaPedido"]
                            };
                        }
                    }
                }
            }

            return pedidoEncontrado;
        }

        public List<Pedido> ListarPedidos()
        {
            List<Pedido> listadoPedidos = new List<Pedido>();
            Pedido pedidoEncontrado = null;

            string sql = "select * from t_pedidos;";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    //comando.Parameters.Add(new SqlParameter("@idPedido", idPedido));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            pedidoEncontrado = new Pedido()
                            {
                                idPedido = (int)resultado["idPedido"],
                                idCliente = (int)resultado["idCliente"],
                                montoTotal = (decimal)resultado["montoTotal"],
                                idEstado = (int)resultado["idEstado"],
                                fechaPedido = (DateTime)resultado["fechaPedido"]                           
                             };
                            listadoPedidos.Add(pedidoEncontrado);
                        }
                    }
                }
            }
            return listadoPedidos;
        }

        public List<Pedido> ListarPedidosCliente(int idCliente)
        {
            List<Pedido> listadoPedidosCliente = new List<Pedido>();
            Pedido pedidoEncontrado = null;

            string sql = "select * from t_pedidos where idCliente=@idCliente;";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            pedidoEncontrado = new Pedido()
                            {
                                idPedido = (int)resultado["idPedido"],
                                idCliente = (int)resultado["idCliente"],
                                montoTotal = (decimal)resultado["montoTotal"],
                                idEstado = (int)resultado["idEstado"],
                                fechaPedido = (DateTime)resultado["fechaPedido"]
                            };
                            listadoPedidosCliente.Add(pedidoEncontrado);
                        }
                    }
                }
            }
            return listadoPedidosCliente;
        }

    }
    
}