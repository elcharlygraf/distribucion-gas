using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTPROYECT.Dominio;
using RESTPROYECT.Persistencia;

namespace RESTPROYECT
{
    public class Clientes : IClientes
    {
        private ClienteDAO dao = new ClienteDAO();

        public Cliente CrearCliente(Clientes clienteACrear)
        {
            return dao.Crear(clienteACrear);
        }

        public Cliente ObtenerCliente(string idCliente)
        {
            return dao.Obtener(idCliente);
        }

        public Cliente ModificarCliente(Clientes clienteAModificar)
        {
            return dao.Modificar(clienteAModificar);
        }

        public void EliminarCliente(string idCliente)
        {
            dao.Eliminar(idCliente);
        }

        public List<Cliente> ListarAClientes()
        {
            return dao.listar();
        }
    }
}
