using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;
using System.Threading.Tasks;

namespace APPCMDPROJECT
{
    class Program
    {
        private static string rutaCola = @".\private$\precioGas";

        static void Main(string[] args)
        {
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(SRWSProducto.Producto) });

            Message mensaje = cola.Receive();
            SRWSProducto.Producto productoRecibido = (SRWSProducto.Producto)mensaje.Body;

            SRWSProducto.ProductosClient proxy = new SRWSProducto.ProductosClient();
            SRWSProducto.Producto productoAModificar = proxy.ModificarProducto(productoRecibido);
        }
    }
}
