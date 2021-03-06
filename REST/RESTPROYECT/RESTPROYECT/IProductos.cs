﻿using RESTPROYECT.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTPROYECT
{
    [ServiceContract]
    public interface IProductos
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "productos", ResponseFormat = WebMessageFormat.Json)]
        Producto CrearProducto(Producto ProductoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "productos/{idProducto}", ResponseFormat = WebMessageFormat.Json)]
        Producto ObtenerProducto(string idProducto);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "productos", ResponseFormat = WebMessageFormat.Json)]
        Producto ModificarProducto(Producto ProductoAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "productos", ResponseFormat = WebMessageFormat.Json)]
        void EliminarProducto(Producto ProductoAEliminar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "productos", ResponseFormat = WebMessageFormat.Json)]
        List<Producto> ListarAProductos();
    }
}
