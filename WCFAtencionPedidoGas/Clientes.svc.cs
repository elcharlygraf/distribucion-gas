using System;
using System.Collections.Generic;
using System.ServiceModel;
using WCFAtencionPedidoGas.Dominio;
using WCFAtencionPedidoGas.Errores;
using WCFAtencionPedidoGas.Persistencia;

namespace WCFAtencionPedidoGas
{
    public class Clientes : IClientes
    {
        private ClienteDAO clienteDAO = new ClienteDAO();

        public Cliente CrearCliente(Cliente clienteACrear)
        {
            if (clienteDAO.Obtener(clienteACrear.telefono) != null)
            {
                throw new FaultException<ValidacionesException>(
                    new ValidacionesException()
                    {
                        Codigo = "101",
                        Descripcion = "El numero de telefono ya existe"
                    },
                    new FaultReason("Error al intentar creacion"));
            }
            return clienteDAO.Crear(clienteACrear);
        }

        public List<Cliente> ListarClientes()
        {
            return clienteDAO.Listar();
        }


        public Cliente ObtenerCliente(string telefono)
        {
            return clienteDAO.Obtener(telefono);
        }
    }
}
