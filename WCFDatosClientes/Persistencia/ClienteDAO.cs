using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFDatosClientes.Dominio;

namespace WCFDatosClientes.Persistencia
{
    public class ClienteDAO
    {
        private string CadenaConexion = "Data Source=(local);Initial Catalog=DB_CLIENTES;Integrated Security=SSPI;";

        public Cliente Crear(Cliente clienteACrear)
        {
            Cliente clienteCreado = null;
            string sql = "INSERT INTO t_clientes values (@telefono, @apellidos, @nombres, @direccion, @distrito)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
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
            clienteCreado = Obtener(clienteACrear.idCliente);
            return clienteCreado;
        }

        public Cliente Obtener(int idCliente)
        {
            Cliente clienteEncontrado = null;
            string sql = "SELECT * FROM t_clientes WHERE idCliente=@idCliente";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idCliente", idCliente));
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

    }
}
