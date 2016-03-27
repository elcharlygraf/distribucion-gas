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
            string sql = "INSERT INTO t_productos VALUES (@producto, @descripcion, @precio)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@producto", ProductoACrear.producto));
                    com.Parameters.Add(new SqlParameter("@descripcion", ProductoACrear.descripcion));
                    com.Parameters.Add(new SqlParameter("@precio", ProductoACrear.precio));
                    com.ExecuteNonQuery();
                }
            }
            ProductoCreado = Obtener(ProductoACrear.idProducto);
            return ProductoCreado;
        }

        public Producto Obtener(string idProducto)
        {
            Producto ProductoEncontrado = null;
            string sql = "SELECT * FROM t_productos WHERE idProducto=@idProducto";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idProducto", idProducto));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            ProductoEncontrado = new Producto()
                            {
                                idProducto  = (string)resultado["idProducto"],
                                producto    = (string)resultado["producto"],
                                descripcion = (string)resultado["descripcion"],
                                precio      = (decimal)resultado["precio"]
                            };
                        }
                    }
                }
            }
            return ProductoEncontrado;
        }

        public Producto Modificar(Producto ProductoAModificar)
        {
            Producto ProductoModificado = null;
            string sql = "UPDATE t_productos SET producto=@producto, descripcion=@descripcion, precio=@precio WHERE idProducto=@idProducto";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@producto", ProductoAModificar.producto));
                    com.Parameters.Add(new SqlParameter("@descripcion", ProductoAModificar.descripcion));
                    com.Parameters.Add(new SqlParameter("@precio", ProductoAModificar.precio));
                    com.ExecuteNonQuery();
                }
            }
            ProductoModificado = Obtener(ProductoAModificar.idProducto);
            return ProductoModificado;
        }

        public void Eliminar(Producto ProductoAEliminar)
        {
            string sql = "DELETE FROM t_productos WHERE idProducto=@idProducto";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idProducto", ProductoAEliminar.idProducto));
                    com.ExecuteNonQuery();
                }
            }
        }

        public List<Producto> listar()
        {
            List<Producto> ProductosEncontrados = new List<Producto>();
            string sql = "Select * from t_productos";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con)) {

                    using (SqlDataAdapter resultado = com.ExecuteReader())
                    {
                    }
                }
                
            }
            return ProductosEncontrados();
        }
        
    }
}
