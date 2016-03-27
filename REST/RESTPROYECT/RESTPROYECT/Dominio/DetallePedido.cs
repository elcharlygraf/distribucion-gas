using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RESTPROYECT.Dominio
{
    [DataContract]
    public class DetallePedido
    {
        [DataMember]
        public string idDetallePedido { get; set; }

        [DataMember]
        public int idPedido { get; set; }

        [DataMember]
        public int idProducto { get; set; }

        [DataMember]
        public int cantidad { get; set; }

        [DataMember]
        public decimal precioUnitario { get; set; }

    }
}