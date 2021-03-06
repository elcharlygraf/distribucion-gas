﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SOAPPROJECT.Dominio
{
    [DataContract]
    public class Producto
    {
        [DataMember]
        public int idProducto { get; set; }

        [DataMember]
        public string producto { get; set; }

        [DataMember]
        public string descripcion { get; set; }

        [DataMember]
        public decimal precio { get; set; }

    }
}
