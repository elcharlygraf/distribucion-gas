﻿using RESTPROYECT.Dominio;
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

        public Cliente Modificar(Cliente clienteAModificar)
        {
            Cliente ClienteModificado = null;
            string sql = "UPDATE t_clientes SET telefono=@telefono, apellidos=@apellidos, nombres=@nombres, direccion=@direccion, distrito=@distrito WHERE idCliente=@idCliente";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
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

        public void Eliminar(Cliente clienteAModificar)
        {
            string sql = "DELETE FROM t_clientes WHERE idCliente=@idCliente";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idCliente", clienteAModificar.idCliente));
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