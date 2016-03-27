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
        public Cliente Crear(Cliente ClienteACrear)
        {
            Cliente ClienteCreado = null;
            string sql = "INSERT INTO t_clientes VALUES (@telefono, @apellidos, @nombres, @direccion, @distrito)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@telefono", ClienteACrear.telefono));
                    com.Parameters.Add(new SqlParameter("@apellidos", ClienteACrear.apellidos));
                    com.Parameters.Add(new SqlParameter("@nombres", ClienteACrear.nombres));
                    com.Parameters.Add(new SqlParameter("@direccion", ClienteACrear.direccion));
                    com.Parameters.Add(new SqlParameter("@distrito", ClienteACrear.distrito));
                    com.ExecuteNonQuery();
                }
            }
            ClienteCreado = Obtener(ClienteACrear.idCliente);
            return ClienteCreado;
        }

        public Cliente Obtener(string idCliente)
        {
            Cliente ClienteEncontrado = null;
            string sql = "SELECT * FROM t_clientes WHERE idCliente=@idCliente";
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
                            ClienteEncontrado = new Cliente()
                            {
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

        public Cliente Modificar(Cliente ClienteAModificar)
        {
            Cliente ClienteModificado = null;
            string sql = "UPDATE t_clientes SET telefono=@telefono, apellidos=@apellidos, nombres=@nombres, direccion=@direccion, distrito=@distrito WHERE idCliente=@idCliente";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@telefono", ClienteAModificar.telefono));
                    com.Parameters.Add(new SqlParameter("@apellidos", ClienteAModificar.apellidos));
                    com.Parameters.Add(new SqlParameter("@nombres", ClienteAModificar.nombres));
                    com.Parameters.Add(new SqlParameter("@direccion", ClienteAModificar.direccion));
                    com.Parameters.Add(new SqlParameter("@distrito", ClienteAModificar.distrito));
                    com.ExecuteNonQuery();
                }
            }
            ClienteModificado = Obtener(ClienteAModificar.idCliente);
            return ClienteModificado;
        }

        public void Eliminar(Cliente ClienteAEliminar)
        {
            string sql = "DELETE FROM t_clientes WHERE idCliente=@idCliente";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idCliente", ClienteAEliminar.idCliente));
                    com.ExecuteNonQuery();
                }
            }
        }

        public List<Cliente> listar()
        {
            List<Cliente> ClientesEncontrados = new List<Cliente>();
            string sql = "Select * from t_clientes";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {

                    using (SqlDataAdapter resultado = com.ExecuteReader())
                    {
                    }
                }

            }
            return ClientesEncontrados();
        }

    }
}