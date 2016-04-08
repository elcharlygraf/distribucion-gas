using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SOAPTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestObtenerDatosCliente()
        {
            ClientesWS.ClientesClient proxy = new ClientesWS.ClientesClient();
            string tipo = "t";
            string var = "3875437";

            ClientesWS.Cliente clienteEncontrado = proxy.ObtenerDatosCliente(tipo,var);
            Assert.AreEqual("3875437", clienteEncontrado.telefono);
            Assert.AreEqual("PEÑA GONZAGA", clienteEncontrado.apellidos);
            Assert.AreEqual("CARLOS", clienteEncontrado.nombres);
            Assert.AreEqual("AV. LOS POSTES ESTE 641", clienteEncontrado.direccion);
            Assert.AreEqual("SJL", clienteEncontrado.distrito);
        }


    }
}
