using System;
using System.Collections.Generic;
using System.Messaging;
using System.Linq;
using System.Web;
using RESTPROYECT.Dominio;

namespace RESTPROYECT.Messaging
{
    public class ProductoMessaging
    {
        private string rutaCola = @".\private$\precioGas";

        public void enviarPrecioVerificacion(Producto sendProductoMsgPrecio)
        {

            
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);

            Message mensaje = new Message();
            mensaje.Label = "PrecioProductoGas";
            mensaje.Body = sendProductoMsgPrecio;

            cola.Send(mensaje); 
        }
            

    }
}