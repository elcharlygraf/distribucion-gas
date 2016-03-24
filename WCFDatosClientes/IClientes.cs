using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFDatosClientes.Dominio;

namespace WCFDatosClientes
{
    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        Cliente CrearCliente(Cliente clienteACrear);

        [OperationContract]
        Cliente ObtenerCliente(int idCliente);

    }
}
