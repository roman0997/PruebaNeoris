using Microsoft.AspNetCore.Mvc;
using PruebaNeoris.Entities.Request;
using PruebaNeoris.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.UnitTest.Cliente
{
    [TestClass]
    public class ClienteTest : Cliente
    {
        [TestMethod]
        public void GetClientes()
        {
            IActionResult result = this.clientesController.GetClientes().Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void AddCliente()
        {
            ClientesRequest clientesRequest = new ClientesRequest()
            {
                Contrasena = "test",
                Direccion = "Test",
                Edad = 20,
                Estado = true,
                Genero = "Masculino",
                Identificacion= "test",
                Nombre= "test",
                Telefono = "test" 
            };
            IActionResult result = this.clientesController.AddCliente(clientesRequest).Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void UpdateCliente()
        {
            ClientesRequest clientesRequest = new ClientesRequest()
            {
                Contrasena = "test",
                Direccion = "Test",
                Edad = 20,
                Estado = true,
                Genero = "Masculino",
                Identificacion = "test",
                Nombre = "test",
                Telefono = "test"
            };
            IActionResult result = this.clientesController.UpdateCliente(clientesRequest).Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void DeleteCliente()
        {
            IActionResult result = this.clientesController.DeleteCliente(1).Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }
    }
}
