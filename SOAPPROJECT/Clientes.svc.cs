
using SOAPPROJECT.Dominio;
using SOAPPROJECT.Excepciones;
using SOAPPROJECT.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAPPROJECT
{
    public class Clientes : IClientes
    {
        private ClienteDAO ClienteDAO = new ClienteDAO();

        public Cliente CrearCliente(Cliente clienteACrear)
        {
            if (ClienteDAO.Obtener(clienteACrear.telefono) != null)
            {
                throw new FaultException<RepetidoExcepcion>(
                    new RepetidoExcepcion()
                    {
                        Codigo = "101",
                        Descripcion = "El cliente ya existe"
                    },
                    new FaultReason("Error al intentar creacion"));
            }
            return ClienteDAO.Crear(clienteACrear);
        }

        public void EliminarCliente(string telefono)
        {
            ClienteDAO.Eliminar(telefono);
        }

        public List<Cliente> ListarClientes()
        {
            return ClienteDAO.Listar();
        }

        public Cliente ModificarCliente(Cliente clienteAModificar)
        {
            return ClienteDAO.Modificar(clienteAModificar);
        }

        public Cliente ObtenerCliente(string telefono)
        {
            return ClienteDAO.Obtener(telefono);
        }

        public Cliente ObtenerDatosCliente(string tipo, string var)
        {
            return ClienteDAO.ObtenerDatos(tipo, var);
        }

    }
}
