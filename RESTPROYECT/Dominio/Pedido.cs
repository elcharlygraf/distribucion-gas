using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RESTPROYECT.Dominio
{
    [DataContract]
    public class Pedido
    {
        [DataMember]
        public int idPedido { get; set; }
        
        [DataMember]
        public int idCliente { get; set; }

        [DataMember]
        public decimal montoTotal { get; set; }

        [DataMember]
        public int idEstado { get; set; }

        [DataMember]
        public DateTime fechaPedido { get; set; }

        [DataMember]
        public DetallePedido detallePedido { get; set; }

    }
}