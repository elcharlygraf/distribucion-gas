using RESTPROYECT.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RESTPROYECT
{
    [ServiceContract]
    public interface IProductos
    {
        [OperationContract]
        Producto CrearProducto(Productos ProductoACrear);

        [OperationContract]
        Producto ObtenerProducto(string idProducto);

        [OperationContract]
        Producto ModificarProducto(Productos ProductoAModificar);

        [OperationContract]
        void EliminarProducto(string idProducto);

        [OperationContract]
        List<Producto> ListarAProductos();
    }
}
