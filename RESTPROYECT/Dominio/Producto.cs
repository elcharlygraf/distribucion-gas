using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RESTPROYECT.Dominio
{
    [DataContract]
    public class Producto
    {
        [DataMember]
        public int idProducto {get; set; }
        
        [DataMember]
        public string producto {get; set; }
        
        [DataMember]
        public string descripcion {get; set; }
        
        [DataMember]
        public decimal precio {get; set; }

        [DataMember]
        public Boolean flgActualizarPrecio { get; set; }

    }
}