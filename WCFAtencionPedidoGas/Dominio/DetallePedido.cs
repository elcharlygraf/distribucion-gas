using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFAtencionPedidoGas.Dominio
{

    [DataContract]
    public class DetallePedido
    {
        [DataMember]
        public int idPedido { get; set; }
        [DataMember]
        public int idProducto { get; set; }
        [DataMember]
        public int cantidad { get; set; }
        [DataMember]
        public double precioUnitario { get; set; }
    }
}