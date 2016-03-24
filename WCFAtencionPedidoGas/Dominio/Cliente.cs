using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFAtencionPedidoGas.Dominio
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int idCliente { get; set; }

        [DataMember]
        public String telefono { get; set; }
    }
}