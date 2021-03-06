﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            string postdata = "{\"producto\":\"yyyy\",\"descripcion\":\"yyyy\",\"precio\":555}";
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
            Assert.AreEqual("yyyy", productoCreado.producto);
            Assert.AreEqual("yyyy", productoCreado.descripcion);
            Assert.AreEqual(555, productoCreado.precio);
        }

        [TestMethod]
        public void TestCrearProductosException()
        {
            string postdata = "{\"producto\":\"xx\",\"descripcion\":\"xxxxx\",\"precio\":89}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1938/Productos.svc/Productos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string productoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Producto productoCreado = js.Deserialize<Producto>(postdata);
                Assert.AreEqual("xx", productoCreado.producto);
                Assert.AreEqual("xxxxx", productoCreado.descripcion);
                Assert.AreEqual(89, productoCreado.precio);
            }
            catch (WebException w)
            {
                HttpStatusCode code = ((HttpWebResponse)w.Response).StatusCode;
                String mensaje = ((HttpWebResponse)w.Response).StatusDescription;
                StreamReader sr = new StreamReader(w.Response.GetResponseStream());
                string error = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensajeException = js.Deserialize<string>(error);
                Assert.AreEqual("El producto: xx no se puede ingresar porque ya existe!", mensajeException);

            }

           
        }
        [TestMethod]
        public void TestObtenerProducto()
        {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.
                Create("http://localhost:1938/Productos.svc/Productos/1");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string productoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Producto productoObtenido = js2.Deserialize<Producto>(productoJson2);
            Assert.AreEqual("5K", productoObtenido.producto);
            Assert.AreEqual("BALON DE 5 KILOS", productoObtenido.descripcion);
            Assert.AreEqual(21, productoObtenido.precio);
        }

        

    }
}
