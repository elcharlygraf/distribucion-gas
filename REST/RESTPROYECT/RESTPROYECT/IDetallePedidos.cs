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
    public interface IDetallePedidos
    {
        [OperationContract]
        DetallePedido CrearDetallePedido(DetallePedidos DetallePedidoACrear);

        [OperationContract]
        DetallePedido ObtenerDetallePedido(string idDetallePedido);

        [OperationContract]
        DetallePedido ModificarDetallePedido(DetallePedidos DetallePedidoAModificar);

        [OperationContract]
        void EliminarDetallePedido(string idDetallePedido);

        [OperationContract]
        List<DetallePedido> ListarADetallePedidos();
    }
}
