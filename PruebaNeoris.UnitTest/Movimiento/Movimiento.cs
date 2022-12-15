using Moq;
using PruebaNeoris.Api.Controllers;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Utils.Enums;
using PruebaNeoris.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.UnitTest.Movimiento
{
    public class Movimiento
    {
        protected Mock<IMovimientosRepository> mockMovimientoRepository = new Mock<IMovimientosRepository>();
        protected Mock<ICuentasRepository> mockCuentaRepository = new Mock<ICuentasRepository>();
        protected MovimientosServices movimientosServices;
        protected MovimientosController movimientosController;
        protected bool Result = true;

        public Movimiento()
        {
            this.mockMovimientoRepository.Setup(x => x.GetMovimientos()).Returns(Task.FromResult(ResponseGetMovimientos()));
            this.mockMovimientoRepository.Setup(x => x.AddMovimiento(It.IsAny<Movimientos>())).Returns(Task.FromResult(Result));
            this.mockMovimientoRepository.Setup(x => x.UpdateMovimiento(It.IsAny<Movimientos>())).Returns(Task.FromResult(Result));
            this.mockMovimientoRepository.Setup(x => x.DeleteMovimiento(It.IsAny<int>())).Returns(Task.FromResult(Result));
            this.mockCuentaRepository.Setup(x => x.UpdateCuenta(It.IsAny<Cuentas>())).Returns(Task.FromResult(Result));
            this.mockCuentaRepository.Setup(x => x.GetCuentaById(It.IsAny<string>())).Returns(Task.FromResult(ResponseGetCuentaById()));
            this.movimientosServices = new MovimientosServices(mockMovimientoRepository.Object, mockCuentaRepository.Object);
            this.movimientosController = new MovimientosController(movimientosServices);
        }

        private List<Movimientos> ResponseGetMovimientos()
        {
            List<Movimientos> Movimientos = new List<Movimientos>();
            Movimientos Movimiento = new Movimientos()
            {
                CuentaId = "12345",
                Fecha = DateTime.Now,
                MovimientoId = 1,
                Saldo = 500,
                TipoMovimiento = TiposMovimiento.retiro.ToString(),
                Valor = 500
            };
            Movimientos.Add(Movimiento);
            return Movimientos;
        }

        private Cuentas ResponseGetCuentaById()
        {
            Cuentas Cuenta = new Cuentas()
            {
                ClienteId = 1,
                Estado = true,
                NumeroCuenta = "12345",
                SaldoInicial = 500,
                TipoCuenta = "Ahorro"
            };
            return Cuenta;
        }
    }
}
