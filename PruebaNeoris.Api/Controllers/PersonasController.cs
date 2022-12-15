using Microsoft.AspNetCore.Mvc;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Utils;
using System.Reflection;

namespace PruebaNeoris.Api.Controllers
{
    public class PersonasController : Controller
    {
        private readonly IPersonasServices personasServices;

        public PersonasController(IPersonasServices _personasServices)
        {
            personasServices = _personasServices;
        }

        [Route("api/persona/getpersonas")]
        [HttpGet]
        public async Task<IActionResult> GetPersonas()
        {
            ApiResponse response;
            response = await personasServices.GetPersonas();
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/persona/addpersona")]
        [HttpPost]
        public async Task<IActionResult> AddPersona([FromBody] Personas persona)
        {

            ApiResponse response;
            response = await personasServices.AddPersona(persona);
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/persona/updatepersona")]
        [HttpPut]
        public async Task<IActionResult> UpdatePersona([FromBody] Personas persona)
        {
            ApiResponse response;
            response = await personasServices.UpdatePersona(persona);
            return StatusCode(response.StatusCode, response);
        }

        [Route("api/persona/deletepersona/{identificacion}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePersona([FromRoute] string identificacion)
        {
            ApiResponse response;
            response = await personasServices.DeletePersona(identificacion);
            return StatusCode(response.StatusCode, response);
        }
    }
}
