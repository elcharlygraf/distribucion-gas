using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace TestClientes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCrearClienteRepetido()
        {
            ClientesWS.ClientesClient proxy = new ClientesWS.ClientesClient();
            try
            {
                ClientesWS.Cliente clienteCreado = proxy.CrearCliente(new ClientesWS.Cliente()
                {
                    telefono = "11"
                });               
            }
            catch(FaultException<ClientesWS.ValidacionesException> error)
            {                
                Assert.AreEqual("Error al intentar creacion", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "El numero de telefono ya existe");
            }
        }
    }
}
