using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFAtencionPedidoGas.Dominio;

namespace WCFAtencionPedidoGas.Persistencia
{
    public class ProductoDAO
    {
        private string CadenaConexion = "Data Source=(local);Initial Catalog=DB_PEDIDOS;Integrated Security=SSPI;";

        public List<Producto> Listar()
        {
            List<Producto> productosEncontrados = new List<Producto>();
            Producto productoEncontrado = default(Producto);
            string sql = "SELECT * FROM t_productos";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
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
