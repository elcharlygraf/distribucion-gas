﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RESTPROYECT.Dominio
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public string idCliente { get; set; }

        [DataMember]
        public string telefono { get; set; }

        [DataMember]
        public string apellidos { get; set; }

        [DataMember]
        public string nombres { get; set; }

        [DataMember]
        public string direccion { get; set; }

        [DataMember]
        public string distrito { get; set; }

    }
}