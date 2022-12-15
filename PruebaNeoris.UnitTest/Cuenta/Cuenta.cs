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

namespace PruebaNeoris.UnitTest.Cuenta
{
    public class Cuenta
    {
        protected Mock<ICuentasRepository> mockCuentaRepository = new Mock<ICuentasRepository>();
        protected CuentasServices cuentasServices;
        protected CuentasController cuentasController;
        protected bool Result = true;

        public Cuenta()
        {
            this.mockCuentaRepository.Setup(x => x.GetCuentas()).Returns(Task.FromResult(ResponseGetCuentas()));
            this.mockCuentaRepository.Setup(x => x.AddCuenta(It.IsAny<Cuentas>())).Returns(Task.FromResult(Result));
            this.mockCuentaRepository.Setup(x => x.UpdateCuenta(It.IsAny<Cuentas>())).Returns(Task.FromResult(Result));
            this.mockCuentaRepository.Setup(x => x.DeleteCuenta(It.IsAny<string>())).Returns(Task.FromResult(Result));
            this.cuentasServices = new CuentasServices(mockCuentaRepository.Object);
            this.cuentasController = new CuentasController(cuentasServices);
        }

        private List<Cuentas> ResponseGetCuentas()
        {
            List<Cuentas> Cuentas = new List<Cuentas>();
            Cuentas Cuenta = new Cuentas()
            {
                ClienteId= 1,
                Estado = true,
                NumeroCuenta = "12345",
                SaldoInicial = 200,
                TipoCuenta = "Ahorro"
            };
            Cuentas.Add(Cuenta);
            return Cuentas;
        }
    }
}
