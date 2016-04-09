using SOAPPROJECT.Dominio;
using SOAPPROJECT.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAPPROJECT
{
    [ServiceContract]
    public interface IProductos
    {
        [FaultContract(typeof(RepetidoExcepcion))]

        [OperationContract]
        Producto CrearProducto(Producto productoACrear);

        [OperationContract]
        Producto ObtenerProducto(string producto);
                
        [OperationContract]
        Producto ModificarProducto(Producto productoAModificar);

        [OperationContract]
        void EliminarProducto(int idProducto);

        [OperationContract]
        List<Producto> ListarProductos();
    }
}
