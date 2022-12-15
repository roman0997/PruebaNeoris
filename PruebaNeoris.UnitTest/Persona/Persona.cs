using Moq;
using PruebaNeoris.Api.Controllers;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.UnitTest.Persona
{
    public class Persona
    {
        protected Mock<IPersonasRepository> mockPersonaRepository = new Mock<IPersonasRepository>();
        protected PersonasServices personasServices;
        protected PersonasController personasController;
        protected bool Result = true;

        public Persona()
        {
            this.mockPersonaRepository.Setup(x => x.GetPersonas()).Returns(Task.FromResult(ResponseGetPersonas()));
            this.mockPersonaRepository.Setup(x => x.AddPersona(It.IsAny<Personas>())).Returns(Task.FromResult(Result));
            this.mockPersonaRepository.Setup(x => x.UpdatePersona(It.IsAny<Personas>())).Returns(Task.FromResult(Result));
            this.mockPersonaRepository.Setup(x => x.DeletePersona(It.IsAny<string>())).Returns(Task.FromResult(Result));
            this.personasServices = new PersonasServices(mockPersonaRepository.Object);
            this.personasController = new PersonasController(personasServices);
        }

        private List<Personas> ResponseGetPersonas()
        {
            List<Personas> Personas = new List<Personas>();
            Personas Persona = new Personas()
            {
                Direccion = "test",
                Edad = 21, 
                Genero = "Masculino",
                Identificacion = "1234",
                Nombre = "Test",
                Telefono = "1234"
            };
            Personas.Add(Persona);
            return Personas;
        }
    }
}
