using SOAPPROJECT.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPPROJECT.Persistencia
{
    public class ProductoDAO
    {
        public Producto Crear(Producto productoACrear)
        {
            Producto productoCreado = null;
            string sql = "INSERT INTO t_productos VALUES (@producto, @descripcion, @precio)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@producto", productoACrear.producto));
                    com.Parameters.Add(new SqlParameter("@descripcion", productoACrear.descripcion));
                    com.Parameters.Add(new SqlParameter("@precio", productoACrear.precio));
                    com.ExecuteNonQuery();
                }
            }
            productoCreado = Obtener(productoACrear.producto);
            return productoCreado;
        }

        public Producto Obtener(string producto)
        {
            Producto productoEncontrado = null;
            string sql = "SELECT * FROM t_productos WHERE producto=@producto";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@producto", producto));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            productoEncontrado = new Producto()
                            {
                                idProducto = (int)resultado["idProducto"],
                                producto = (string)resultado["producto"],
                                descripcion = (string)resultado["descripcion"],
                                precio = (decimal)resultado["precio"]
                            };
                        }
                    }
                }
            }
            return productoEncontrado;
        }

        public Producto Modificar(Producto productoAModificar)
        {
            Producto productoModificado = null;
            string sql = "UPDATE t_productos SET producto=@producto, descripcion=@descripcion, precio=@precio WHERE idProducto=@idProducto";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idCliente", productoAModificar.producto));
                    comando.Parameters.Add(new SqlParameter("@telefono", productoAModificar.descripcion));                    
                    comando.Parameters.Add(new SqlParameter("@distrito", productoAModificar.precio));
                    comando.ExecuteNonQuery();
                }
            }
            productoModificado = Obtener(productoAModificar.producto);
            return productoModificado;
        }

        public void Eliminar(int idProducto)
        {
            string sql = "DELETE * FROM t_productos WHERE idProducto=@idProducto";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add(new SqlParameter("@idProducto", idProducto));
                    comando.ExecuteNonQuery();
                }
            }

        }

        public List<Producto> ListarTodos()
        {
            List<Producto> productosEncontrados = new List<Producto>();
            Producto productoEncontrado = default(Producto);
            string sql = "SELECT * FROM t_productos";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            productoEncontrado = new Producto()
                            {
                                idProducto = (int)resultado["idProducto"],
                                producto = (string)resultado["producto"],
                                descripcion = (string)resultado["descripcion"],
                                precio = (decimal)resultado["precio"]
                            };
                            productosEncontrados.Add(productoEncontrado);
                        }
                    }
                }
            }
            return productosEncontrados;

        }

    }
}
