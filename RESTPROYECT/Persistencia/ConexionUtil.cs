﻿﻿using System;
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
                return "Data Source=(local);Initial Catalog=DB_PEDIDOS;Integrated Security=SSPI;";
            }
        }

        public static string CadenaClientes
        {
            get
            {
                return "Data Source=(local);Initial Catalog=DB_CLIENTES;Integrated Security=SSPI;";
            }
        }
    }
}