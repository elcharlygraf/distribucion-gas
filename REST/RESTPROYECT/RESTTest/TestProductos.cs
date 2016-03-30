using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RESTTest
{
    [TestClass]
    public class TestProductos
    {
        [TestMethod]
        public void TestCrearProductos()
        {
            string postdata = "{\"producto\":\"aaaaaaa\",\"descripcion\":\"qqqqqqqq\",\"precio\":1111}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1938/Productos.svc/Productos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string productoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Producto productoCreado = js.Deserialize<Producto>(postdata);
            Assert.AreEqual("aaaaaaa", productoCreado.producto);
            Assert.AreEqual("qqqqqqqq", productoCreado.descripcion);
            Assert.AreEqual(1111, productoCreado.precio);            
        }

        

    }
}
