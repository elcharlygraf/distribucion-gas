using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFClientes.Dominio;

namespace WCFClientes.Persistencia
{
    public class DatosClienteDAO
    {
        private string CadenaConexion = "Data Source=(local);Initial Catalog=DB_CLIENTES;Integrated Security=SSPI;";

        public DatosCliente Crear(DatosCliente clienteACrear)
        {
            DatosCliente clienteCreado = null;
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
            clienteCreado = ObtenerDatos(clienteACrear.idCliente);
            return clienteCreado;
        }

        public DatosCliente ObtenerDatos(int idCliente)
        {
            DatosCliente clienteEncontrado = null;
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
                            clienteEncontrado = new DatosCliente()
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
