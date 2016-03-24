using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAtencionPedidoGas.Dominio;
using WCFAtencionPedidoGas.Persistencia;

namespace WCFAtencionPedidoGas
{
    public class Productos : IProductos
    {
        private ProductoDAO productoDAO = new ProductoDAO();

        public List<Producto> ListarProductos()
        {
            return productoDAO.Listar();
        }

    }
}
