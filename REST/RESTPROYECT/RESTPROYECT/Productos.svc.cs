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

        public Producto CrearProducto(Productos ProductoACrear)
        {
            return dao.Crear(ProductoACrear);
        }

        public Producto ObtenerProducto(string idProducto)
        {
            return dao.Obtener(idProducto);
        }

        public Producto ModificarProducto(Productos ProductoAModificar)
        {
            return dao.Modificar(ProductoAModificar);
        }

        public void EliminarProducto(string idProducto)
        {
            dao.Eliminar(idProducto);
        }

        public List<Producto> ListarAProductos()
        {
            return dao.listar();
        }
    }
}
