using Microsoft.AspNetCore.Mvc;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Utils;
using PruebaNeoris.Entities.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.UnitTest.Movimiento
{
    [TestClass]
    public class MovimientoTest : Movimiento
    {
        [TestMethod]
        public void GetMovimientos()
        {
            IActionResult result = this.movimientosController.GetMovimientos().Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void AddMovimiento()
        {
            Movimientos movimiento = new Movimientos()
            {
                CuentaId = "12354",
                TipoMovimiento = TiposMovimiento.retiro.ToString(),
                Valor = 500
            };
            IActionResult result = this.movimientosController.AddMovimiento(movimiento).Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void UpdateMovimiento()
        {
            Movimientos movimiento = new Movimientos()
            {
                CuentaId = "12354",
                TipoMovimiento = TiposMovimiento.retiro.ToString(),
                Valor = 500
            };
            IActionResult result = this.movimientosController.UpdateMovimiento(movimiento).Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }

        [TestMethod]
        public void DeleteMovimiento()
        {
            IActionResult result = this.movimientosController.DeleteMovimiento(1).Result;
            ApiResponse response = (ApiResponse)((ObjectResult)result).Value;
            Assert.AreNotEqual(response, null);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Errors.Count, 0);
        }
    }
}
