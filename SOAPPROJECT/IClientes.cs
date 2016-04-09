using SOAPPROJECT.Dominio;
using SOAPPROJECT.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAPPROJECT
{
    [ServiceContract]
    public interface IClientes
    {
        [FaultContract(typeof(RepetidoExcepcion))]

        [OperationContract]
        Cliente CrearCliente(Cliente clienteACrear);

        [OperationContract]
        Cliente ObtenerCliente(string telefono);

        [OperationContract]
        Cliente ObtenerDatosCliente(string tipo, string var);

        [OperationContract]
        Cliente ModificarCliente(Cliente clienteAModificar);

        [OperationContract]
        void EliminarCliente(string teelfono);

        [OperationContract]
        List<Cliente> ListarClientes();
        //

    }
}
