using SOAPPROJECT.Dominio;
using SOAPPROJECT.Excepciones;
using SOAPPROJECT.Persistencia;
using System.Collections.Generic;
using System.ServiceModel;

namespace SOAPPROJECT
{
    public class Productos : IProductos
    {
        private ProductoDAO productoDAO = new ProductoDAO();

        public Producto CrearProducto(Producto productoACrear)
        {
            if (productoDAO.Obtener(productoACrear.producto) != null)
            {
                throw new FaultException<RepetidoExcepcion>(
                    new RepetidoExcepcion()
                    {
                        Codigo = "102",
                        Descripcion = "El producto ya existe"
                    },
                    new FaultReason("Error al intentar creacion"));

            }

            return productoDAO.Crear(productoACrear);
        }

        public Producto ObtenerProducto(string producto)
        {            
            return productoDAO.Obtener(producto);
        }

        public Producto ModificarProducto(Producto productoAModificar)
        {
            return productoDAO.Modificar(productoAModificar);
        }

        public void EliminarProducto(int idProducto)
        {
            productoDAO.Eliminar(idProducto);
        }

        public List<Producto> ListarProductos()
        {
            return productoDAO.ListarTodos();
        }

    }
}
