using Microsoft.AspNetCore.Mvc;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Request;
using PruebaNeoris.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.UnitTest.Cuenta
{
    [TestClass]
    public class CuentaTest : Cuenta
    {
        [TestMethod]
        public void GetCuentas()
        {
            IActionResult result = this.cuentasController.GetCuentas().Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void AddCuenta()
        {
            Cuentas cuenta = new Cuentas()
            {
                ClienteId = 1,
                Estado = true,
                NumeroCuenta = "1234",
                SaldoInicial = 500,
                TipoCuenta = "Ahorro"
            };
            IActionResult result = this.cuentasController.AddCuenta(cuenta).Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void UpdateCuenta()
        {
            Cuentas cuenta = new Cuentas()
            {
                ClienteId = 1,
                Estado = true,
                NumeroCuenta = "1234",
                SaldoInicial = 500,
                TipoCuenta = "Ahorro"
            };
            IActionResult result = this.cuentasController.UpdateCuenta(cuenta).Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void DeleteCuenta()
        {
            IActionResult result = this.cuentasController.DeleteCuenta("1234").Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }
    }
}
