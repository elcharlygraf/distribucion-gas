
using SOAPPROJECT.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPPROJECT.Persistencia
{
    public class ClienteDAO
    {
        public Cliente Crear(Cliente clienteACrear)
        {
            Cliente clienteCreado = null;
            string sql = "INSERT INTO t_clientes values (@telefono, @apellidos, @nombres, @direccion, @distrito)";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@telefono", clienteACrear.telefono));
                    comando.Parameters.Add(new SqlParameter("@apellidos", clienteACrear.apellidos));
                    comando.Parameters.Add(new SqlParameter("@nombres", clienteACrear.nombres));
                    comando.Parameters.Add(new SqlParameter("@direccion", clienteACrear.direccion));
                    comando.Parameters.Add(new SqlParameter("@distrito", clienteACrear.distrito));
                    comando.ExecuteNonQuery();
                }
            }
            clienteCreado = Obtener(clienteACrear.telefono);
            return clienteCreado;
        }

        public Cliente ObtenerDatos(string tipo, string var)
        {
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
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@var", var));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
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
            return clienteEncontrado;
        }

        public Cliente Obtener(string telefono)
        {
            Cliente clienteEncontrado = null;
            string sql = "SELECT * FROM t_clientes WHERE telefono=@telefono";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.CadenaClientes))
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
            return clienteEncontrado;
        }

        public void Eliminar(string telefono)
        {
            string sql = "DELETE FROM t_cliente WHERE telefono=@telefono";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@telefono", telefono));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Cliente> Listar()
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
            Cliente clienteModificado = null;
            string sql = "UPDATE t_clientes SET telefono=@telefono, apellidos=@apellidos, nombres=@nombres, direccion=@direccion, distrito=@distrito WHERE idCliente=@idCliente";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idCliente", clienteAModificar.idCliente));
                    comando.Parameters.Add(new SqlParameter("@telefono", clienteAModificar.telefono));
                    comando.Parameters.Add(new SqlParameter("@apellidos", clienteAModificar.apellidos));
                    comando.Parameters.Add(new SqlParameter("@nombres", clienteAModificar.nombres));
                    comando.Parameters.Add(new SqlParameter("@direccion", clienteAModificar.direccion));
                    comando.Parameters.Add(new SqlParameter("@distrito", clienteAModificar.distrito));
                    comando.ExecuteNonQuery();
                }
            }
            clienteModificado = Obtener(clienteAModificar.telefono);
            return clienteModificado;
        }

        public Cliente BuscaDuplicado()
        {
            return null;
        }

    }
}
