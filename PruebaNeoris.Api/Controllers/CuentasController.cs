using Microsoft.AspNetCore.Mvc;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Utils;

namespace PruebaNeoris.Api.Controllers
{
    public class CuentasController : Controller
    {
        private readonly ICuentasServices cuentasServices;

        public CuentasController(ICuentasServices _cuentasServices)
        {
            cuentasServices = _cuentasServices;
        }

        [Route("api/cuenta/getcuentas")]
        [HttpGet]
        public async Task<IActionResult> GetCuentas()
        {
            ApiResponse response;
            response = await cuentasServices.GetCuentas();
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/cuenta/addcuenta")]
        [HttpPost]
        public async Task<IActionResult> AddCuenta([FromBody]Cuentas cuenta)
        {

            ApiResponse response;
            response = await cuentasServices.AddCuenta(cuenta);
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/cuenta/updatecuenta")]
        [HttpPut]
        public async Task<IActionResult> UpdateCuenta([FromBody]Cuentas cuenta)
        {
            ApiResponse response;
            response = await cuentasServices.UpdateCuenta(cuenta);
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/cuenta/deletecuenta/{numerocuenta}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCuenta([FromRoute] string numerocuenta)
        {
            ApiResponse response;
            response = await cuentasServices.DeleteCuenta(numerocuenta);
            return StatusCode(response.StatusCode, response);
        }
    }
}
