using Moq;
using PruebaNeoris.Api.Controllers;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Request;
using PruebaNeoris.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.UnitTest.Cliente
{
    public class Cliente
    {
        protected Mock<IClientesRepository> mockClienteRepository = new Mock<IClientesRepository>();
        protected Mock<IPersonasRepository> mockPersonasRepository = new Mock<IPersonasRepository>();
        protected ClientesServices clientesServices;
        protected ClientesController clientesController;
        protected bool Result = true;

        public Cliente()
        {
            this.mockClienteRepository.Setup(x => x.GetClientes()).Returns(Task.FromResult(ResponseGetClientes()));
            this.mockClienteRepository.Setup(x => x.AddCliente(It.IsAny<Clientes>())).Returns(Task.FromResult(Result));
            this.mockClienteRepository.Setup(x => x.UpdateCliente(It.IsAny<Clientes>())).Returns(Task.FromResult(Result));
            this.mockClienteRepository.Setup(x => x.DeleteCliente(It.IsAny<int>())).Returns(Task.FromResult(Result));
            this.mockPersonasRepository.Setup(x => x.AddPersona(It.IsAny<Personas>())).Returns(Task.FromResult(Result));
            this.clientesServices = new ClientesServices(mockClienteRepository.Object, mockPersonasRepository.Object);
            this.clientesController = new ClientesController(clientesServices);
        }

        private List<Clientes> ResponseGetClientes()
        {
            List<Clientes> clientes = new List<Clientes>();
            Clientes cliente = new Clientes()
            {
                ClienteId = 1,
                Contrasena = "1234",
                Estado = true,
                PersonaId = "1234"
            };
            clientes.Add(cliente);
            return clientes;
        }
    }
}
