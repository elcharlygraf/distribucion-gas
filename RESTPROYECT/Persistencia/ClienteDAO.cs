using RESTPROYECT.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RESTPROYECT.Persistencia
{
    public class ClienteDAO
    {
        public Cliente Crear(Cliente clienteACrear)
        {
            Cliente ClienteCreado = null;
            string sql = "INSERT INTO t_clientes VALUES (@telefono, @apellidos, @nombres, @direccion, @distrito)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@telefono", clienteACrear.telefono));
                    com.Parameters.Add(new SqlParameter("@apellidos", clienteACrear.apellidos));
                    com.Parameters.Add(new SqlParameter("@nombres", clienteACrear.nombres));
                    com.Parameters.Add(new SqlParameter("@direccion", clienteACrear.direccion));
                    com.Parameters.Add(new SqlParameter("@distrito", clienteACrear.distrito));
                    com.ExecuteNonQuery();
                }
            }
            ClienteCreado = Obtener(clienteACrear.idCliente);
            return ClienteCreado;
        }

        public Cliente Obtener(int idCliente)
        {
            Cliente ClienteEncontrado = null;
            string sql = "SELECT * FROM t_clientes WHERE idCliente=@idCliente";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            ClienteEncontrado = new Cliente()
                            {
                                idCliente = (int)resultado["idCliente"],
                                telefono  = (string)resultado["telefono"],
                                apellidos = (string)resultado["apellidos"],
                                nombres   = (string)resultado["nombres"],
                                direccion = (string)resultado["direccion"],
                                distrito  = (string)resultado["distrito"]
                            };
                        }
                    }
                }
            }
            return ClienteEncontrado;
        }

        public Cliente Obtener(string telefono)
        {
            Cliente ClienteEncontrado = null;
            string sql = "SELECT * FROM t_clientes WHERE telefono=@telefono";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@telefono", telefono));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            ClienteEncontrado = new Cliente()
                            {
                                idCliente = (int)resultado["idCliente"],
                                telefono = (string)resultado["telefono"],
                                apellidos = (string)resultado["apellidos"],
                                nombres = (string)resultado["nombres"],
                                direccion = (string)resultado["direccion"],
                                distrito = (string)resultado["distrito"]
                            };
                        }
                    }
                }
            }
            return ClienteEncontrado;
        }

        public List<Cliente> Buscar(string tipo, string var)
        {
            List<Cliente> clientesEncontrados = new List<Cliente>();
            Cliente clienteEncontrado = null;
            string sql = null;

            if (tipo == "t")
            {
                sql = "SELECT * FROM t_clientes WHERE telefono=@var";
            }
            else
            {
                if (tipo == "n")
                {
                    sql = "SELECT * FROM t_clientes WHERE nombres like '%" + @var + "%'";
                }
                else
                {
                    if (tipo == "d")
                    {
                        sql = "SELECT * FROM t_clientes WHERE direccion like '%" + @var + "%'";
                    }
                }
            }
            
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@var", var));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                idCliente = (int)resultado["idCliente"],
                                telefono = (string)resultado["telefono"],
                                apellidos = (string)resultado["apellidos"],
                                nombres = (string)resultado["nombres"],
                                direccion = (string)resultado["direccion"],
                                distrito = (string)resultado["distrito"]
                            };
                            clientesEncontrados.Add(clienteEncontrado);
                        }
                    }
                }
            }
            return clientesEncontrados;
        }

        public Cliente Modificar(Cliente clienteAModificar)
        {
            Cliente ClienteModificado = null;
            string sql = "UPDATE t_clientes SET telefono=@telefono, apellidos=@apellidos, nombres=@nombres, direccion=@direccion, distrito=@distrito WHERE idCliente=@idCliente";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    //com.Parameters.Add(new SqlParameter("@idCliente", clienteAModificar.idCliente));
                    com.Parameters.Add(new SqlParameter("@telefono", clienteAModificar.telefono));
                    com.Parameters.Add(new SqlParameter("@apellidos", clienteAModificar.apellidos));
                    com.Parameters.Add(new SqlParameter("@nombres", clienteAModificar.nombres));
                    com.Parameters.Add(new SqlParameter("@direccion", clienteAModificar.direccion));
                    com.Parameters.Add(new SqlParameter("@distrito", clienteAModificar.distrito));
                    com.ExecuteNonQuery();
                }
            }
            ClienteModificado = Obtener(clienteAModificar.idCliente);
            return ClienteModificado;
        }

        public void Eliminar(Cliente clienteAEliminar)
        {
            string sql = "DELETE FROM t_clientes WHERE idCliente=@idCliente";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idCliente", clienteAEliminar.idCliente));
                    com.ExecuteNonQuery();
                }
            }
        }

        public List<Cliente> listar()
        {
            List<Cliente> clientesEncontrados = new List<Cliente>();
            Cliente clienteEncontrado = default(Cliente);
            string sql = "SELECT * FROM t_clientes";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.CadenaClientes))
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
                                idCliente = (int)resultado["idCliente"],
                                telefono = (string)resultado["telefono"],
                                apellidos = (string)resultado["apellidos"],
                                nombres = (string)resultado["nombres"],
                                distrito = (string)resultado["distrito"]
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