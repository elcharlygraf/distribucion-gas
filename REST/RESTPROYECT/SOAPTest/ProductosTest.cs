using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOAPTest
{
    [TestClass]
    public class ProductosTest
    {
        [TestMethod]
        public void TestCrearProducto()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            ProductosWS.Producto productoCreado = proxy.CrearProducto(new ProductosWS.Producto()
            {
                producto = "EEE",
                descripcion = "EEE",
                precio = 1580
            });
            Assert.AreEqual("EEE", productoCreado.producto);
            Assert.AreEqual("EEE", productoCreado.descripcion);
            Assert.AreEqual(1580, productoCreado.precio);
        }

        [TestMethod]
        public void TestCrearProductoRepetido()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            try
            {
                ProductosWS.Producto productosCreado = proxy.CrearProducto(new ProductosWS.Producto()
                {
                    producto = "EEE",
                    descripcion = "EEE",
                    precio = 1580
                });
            }
            catch (FaultException<ProductosWS.RepetidoExcepcion> error)
            {
                Assert.AreEqual("Error al intentar creacion", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "102");
                Assert.AreEqual(error.Detail.Descripcion, "El producto ya existe");
            }

        }

        [TestMethod]
        public void TestModificarProducto()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            int idProducto = 41;
            ProductosWS.Producto productoAModificar = proxy.ModificarProducto(proxy.ObtenerProducto(idProducto)
                {
                productoAModificar.producto = "PRUEBA";
                productoAModificar.descripcion = "PRUEBA";
                productoAModificar.precio = 666;
            })            
            Assert.AreEqual(41, productoAModificar.idProducto);
            Assert.AreEqual("PRUEBA", productoAModificar.producto);
            Assert.AreEqual("PRUEBA", productoAModificar.descripcion);
            Assert.AreEqual(666, productoAModificar.precio);
        }

        [TestMethod]
        public void TestListarProductos()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            proxy.ListarProductos();
        }
    }
}
