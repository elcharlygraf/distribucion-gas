﻿using RESTPROYECT.Dominio;
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
            string sqlIdentity = "Select @@Identity";
            int idPedidoCreado;
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
                    com.CommandText = sqlIdentity;

                    idPedidoCreado = (int)com.ExecuteScalar();

                }
            }
            PedidoCreado = Obtener(idPedidoCreado);
            return PedidoCreado;
        }

        public Pedido Obtener(int idCliente)
        {
            Pedido PedidoEncontrado = null;
            string sql = "SELECT * FROM t_pedidos WHERE idCliente=@idCliente";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            PedidoEncontrado = new Pedido()
                            {
                                idCliente = (int)resultado["idCliente"],
                                montoTotal = (decimal)resultado["montoTotal"],
                                idEstado = (int)resultado["idEstado"],
                                fechaPedido = (DateTime)resultado["fechaPedido"]
                            };
                        }
                    }
                }
            }
            return PedidoEncontrado;
        }

        public Pedido Obtener(string idCliente)
        {
            Pedido PedidoEncontrado = null;
            string sql = "SELECT * FROM t_pedidos WHERE idCliente=@idCliente";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            PedidoEncontrado = new Pedido()
                            {
                                idCliente = (int)resultado["idCliente"],
                                montoTotal = (decimal)resultado["montoTotal"],
                                idEstado = (int)resultado["idEstado"],
                                fechaPedido = (DateTime)resultado["fechaPedido"]
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
            string sql = "DELETE d,p " +
                        "FROM t_detallePedido d" +
                        "INNER JOIN t_pedidos p" +
                         " ON idPedido=idPedido" +
                        "Where idPedido=@idPedido ";
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

        public List<Pedido> listar(int idCliente)
        {
            List<Pedido> pedidosEncontrados = new List<Pedido>();
            Pedido PedidoEncontrado = default(Pedido);
            string sql = "SELECT  P.idCliente,P.montoTotal,P.idEstado,P.fechaPedido, D.cantidad, D.precioUnitario" +
                         "FROM t_pedidos P INNER JOIN t_detallePedido D ON P.idPedido=D.idPedido WHERE idCliente=@idCliente";
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
                                fechaPedido = (DateTime)resultado["fechaPedido"],
                                detallePedido = new DetallePedido()
                                {
                                    cantidad = (int)resultado["cantidad"],
                                    precioUnitario = (decimal)resultado["precioUnitario"]
                                }

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