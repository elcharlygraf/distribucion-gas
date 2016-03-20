using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFClientes.Dominio;

namespace WCFClientes
{
    [ServiceContract]
    public interface IDatosClientes
    {
        [OperationContract]
        DatosCliente CrearCliente(DatosCliente clienteACrear);

        [OperationContract]
        DatosCliente ObtenerDatosCliente(int idCliente);        
    }
}
