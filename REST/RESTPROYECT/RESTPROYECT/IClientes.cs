using RESTPROYECT.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RESTPROYECT
{
    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        Cliente CrearCliente(Clientes clienteACrear);

        [OperationContract]
        Cliente ObtenerCliente(string idCliente);

        [OperationContract]
        Cliente ModificarCliente(Clientes clienteAModificar);

        [OperationContract]
        void EliminarCliente(string idCliente);

        [OperationContract]
        List<Cliente> ListarAClientes();
    }
}
