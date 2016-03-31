using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTPROYECT.Dominio;
using RESTPROYECT.Persistencia;
using System.ServiceModel.Web;
using System.Net;

namespace RESTPROYECT
{
    public class Clientes : IClientes
    {
        private ClienteDAO dao = new ClienteDAO();

        public Cliente CrearCliente(Cliente clienteACrear){
        
            Cliente clienteObtenido = dao.Obtener(clienteACrear.telefono);

            if (clienteObtenido != null)
            {
                throw new WebFaultException<string>(
                    "El cliente con el # de telefono " + clienteACrear.telefono + " ya existe!", HttpStatusCode.InternalServerError);
            }
            return dao.Crear(clienteACrear);
        }

        public Cliente ObtenerCliente(string idClientetmp)
        {
            int idCliente = Int32.Parse(idClientetmp);
            return dao.Obtener(idCliente);
        }

        public Cliente ModificarCliente(Cliente clienteAModificar)
        {
            return dao.Modificar(clienteAModificar);
        }

        public void EliminarCliente(Cliente clienteAEliminar)
        {
            dao.Eliminar(clienteAEliminar);
        }

        public List<Cliente> ListarAClientes()
        {
            return dao.listar();
        }

    }
}
