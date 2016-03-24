using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WCFAtencionPedidoGas.Dominio;

namespace WCFAtencionPedidoGas.Persistencia
{
    public class ClienteDAO
    {

        public string cadenaConexion = "Data Source=(local);Initial Catalog=DB_PEDIDOS;Integrated Security=SSPI;";
        
        public Cliente Crear(Cliente clienteACrear)
        {
            Cliente clienteCreado = null;
            string sql = "INSERT INTO t_clientes VALUES (@telefono)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@telefono", clienteACrear.telefono));
                    comando.ExecuteNonQuery();
                }
            }

            clienteCreado = Obtener(clienteACrear.telefono);
            return clienteCreado;
        }

        public Cliente Actualizar(Cliente clienteAModificar)
        {

            Cliente clienteModificado = null;
            string sql = "UPDATE t_clientes SET telefono=@telefono WHERE idCliente=@idCliente";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idCliente", clienteAModificar.idCliente));
                    comando.Parameters.Add(new SqlParameter("@telefono", clienteAModificar.telefono));
                    comando.ExecuteNonQuery();
                }
            }
            clienteModificado = Obtener(clienteAModificar.telefono);
            return clienteModificado;
        }

        public Cliente Obtener(string telefono)
        {
            Cliente clienteEncontrado = null;

            string sql = "SELECT * FROM t_clientes WHERE telefono=@telefono";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@telefono", telefono));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                idCliente = (int)resultado["idCliente"],
                                telefono = (string)resultado["telefono"]
                            };
                        }
                    }
                }
            }

            return clienteEncontrado;
        }

        public List<Cliente> Listar()
        {
            List<Cliente> clientesEncontrados = new List<Cliente>();
            Cliente clienteEncontrado = default(Cliente);
            string sql = "SELECT * FROM t_clientes";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                //idCliente = (int)resultado["id_Cliente"],
                                telefono = (string)resultado["telefono"]                                
                            };
                            clientesEncontrados.Add(clienteEncontrado);
                        }
                    }
                }
            }
            return clientesEncontrados;
        }



    }
}