using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTPROYECT.Dominio;
using RESTPROYECT.Persistencia;
using System.ServiceModel.Web;
using System.Net;

namespace RESTPROYECT
{
    public class Productos : IProductos
    {
        private ProductoDAO dao = new ProductoDAO();

        public Producto CrearProducto(Producto ProductoACrear)
        {
            if (dao.Equals(ProductoACrear.producto))
            {
                throw new WebFaultException<string>("Producto imposible", HttpStatusCode.InternalServerError);
            }
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
