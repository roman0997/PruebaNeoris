using Microsoft.AspNetCore.Mvc;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Utils;

namespace PruebaNeoris.Api.Controllers
{
    public class MovimientosController : Controller
    {
        private readonly IMovimientosServices movimientosServices;

        public MovimientosController(IMovimientosServices _movimientosServices)
        {
            movimientosServices = _movimientosServices;
        }

        [Route("api/movimiento/getmovimientos")]
        [HttpGet]
        public async Task<IActionResult> GetMovimientos()
        {
            ApiResponse response;
            response = await movimientosServices.GetMovimientos();
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/movimiento/addmovimiento")]
        [HttpPost]
        public async Task<IActionResult> AddMovimiento([FromBody] Movimientos movimiento)
        {

            ApiResponse response;
            response = await movimientosServices.AddMovimiento(movimiento);
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/movimiento/updatemovimiento")]
        [HttpPut]
        public async Task<IActionResult> UpdateMovimiento([FromBody] Movimientos movimiento)
        {
            ApiResponse response;
            response = await movimientosServices.UpdateMovimiento(movimiento);
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/movimiento/deletemovimiento/{movimientoid}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMovimiento([FromRoute] int movimientoid)
        {
            ApiResponse response;
            response = await movimientosServices.DeleteMovimiento(movimientoid);
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/movimiento/reportes/{startDate}/{endDate}/{identificacion}")]
        [HttpGet]
        public async Task<IActionResult> Reporte([FromRoute] string startDate, string endDate, string identificacion)
        {
            ApiResponse response;
            response = await movimientosServices.Reporte(startDate, endDate, identificacion);
            return StatusCode(response.StatusCode, response);
        }
    }
}
