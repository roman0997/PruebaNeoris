using Microsoft.AspNetCore.Mvc;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.UnitTest.Persona
{
    [TestClass]
    public class PersonaTest : Persona
    {
        [TestMethod]
        public void GetPersonas()
        {
            IActionResult result = this.personasController.GetPersonas().Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void AddPersona()
        {
            Personas persona = new Personas()
            {
                Direccion = "test",
                Edad = 21,
                Genero = "Masculino",
                Identificacion = "1234",
                Nombre = "Test",
                Telefono = "1234"
            };
            IActionResult result = this.personasController.AddPersona(persona).Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void UpdatePersona()
        {
            Personas persona = new Personas()
            {
                Direccion = "test",
                Edad = 21,
                Genero = "Masculino",
                Identificacion = "1234",
                Nombre = "Test",
                Telefono = "1234"
            };
            IActionResult result = this.personasController.UpdatePersona(persona).Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void DeletePersona()
        {
            IActionResult result = this.personasController.DeletePersona("1234").Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }
    }
}
