using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAtencionPedidoGas.Dominio;
using WCFAtencionPedidoGas.Errores;

namespace WCFAtencionPedidoGas
{
    
    [ServiceContract]
    public interface IClientes
    {
        [FaultContract(typeof(ValidacionesException))]

        [OperationContract]
        Cliente CrearCliente(Cliente clienteACrear);

        [OperationContract]
        Cliente ObtenerCliente(string telefono);

        [OperationContract]
        List<Cliente> ListarClientes();
    }
}
