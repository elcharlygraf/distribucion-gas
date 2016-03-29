using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTPROYECT.Dominio;
using RESTPROYECT.Persistencia;

namespace RESTPROYECT
{
    public class Productos : IProductos
    {
        private ProductoDAO dao = new ProductoDAO();

        public Producto CrearProducto(Producto ProductoACrear)
        {
            return dao.Crear(ProductoACrear);
        }

        public Producto ObtenerProducto(string idProductotmp)
        {
            int idProducto = Int32.Parse(idProductotmp);
            return dao.Obtener(idProducto);
        }

        public Producto ModificarProducto(Producto ProductoAModificar)
        {
            return dao.Modificar(ProductoAModificar);
        }

        public void EliminarProducto(Producto ProductoAEliminar)
        {
            dao.Eliminar(ProductoAEliminar);
        }

        public List<Producto> ListarAProductos()
        {
            return dao.Listar();
        }
    }
}
