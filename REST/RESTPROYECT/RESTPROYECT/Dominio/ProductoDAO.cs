using RESTPROYECT.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RESTPROYECT.Dominio
{

    public class ProductoDAO
    {
        public Producto Crear(Producto ProductoACrear)
        {
            Producto ProductoCreado = null;
            string sql = "INSERT INTO t_productos VALUES (@cod, @nom)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", ProductoACrear.Codigo));
                    com.Parameters.Add(new SqlParameter("@nom", ProductoACrear.Nombre));
                    com.ExecuteNonQuery();
                }
            }
            ProductoCreado = Obtener(ProductoACrear.Codigo);
            return ProductoCreado;
        }
        public Producto Obtener(string codigo)
        {
            Producto ProductoEncontrado = null;
            string sql = "SELECT * FROM t_productos WHERE codigo=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            ProductoEncontrado = new Producto()
                            {
                                Codigo = (string)resultado["codigo"],
                                Nombre = (string)resultado["nombre"]
                            };
                        }
                    }
                }
            }
            return ProductoEncontrado;
        }
        public Producto Modificar(Producto ProductoAModificar)
        {
            return null;
        }
        public void Eliminar(Producto ProductoAEliminar)
        {

        }
        public List<Producto> ListarTodos()
        {
            return null;
        }
    }
}