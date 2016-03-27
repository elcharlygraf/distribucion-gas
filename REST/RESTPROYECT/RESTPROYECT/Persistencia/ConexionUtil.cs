﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTPROYECT.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                return "Data Source=(local);Initial Catalog=BD_PEDIDOS;Integrated Security=SSPI;";
            }
        }
    }
}