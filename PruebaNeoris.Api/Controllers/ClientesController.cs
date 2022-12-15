using Microsoft.AspNetCore.Mvc;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Request;
using PruebaNeoris.Entities.Utils;

namespace PruebaNeoris.Api.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClientesServices clientesServices;

        public ClientesController(IClientesServices _clientesServices)
        {
            clientesServices = _clientesServices;
        }

        [Route("api/cliente/getclientes")]
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            ApiResponse response;
            response = await clientesServices.GetClientes();
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/cliente/addcliente")]
        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] ClientesRequest cliente)
        {

            ApiResponse response;
            response = await clientesServices.AddCliente(cliente);
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/cliente/updatecliente")]
        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] ClientesRequest cliente)
        {
            ApiResponse response;
            response = await clientesServices.UpdateCliente(cliente);
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/cliente/deletecliente/{clienteid}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCliente([FromRoute] int clienteid)
        {
            ApiResponse response;
            response = await clientesServices.DeleteCliente(clienteid);
            return StatusCode(response.StatusCode, response);
        }
    }
}
