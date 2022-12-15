using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Response;
using PruebaNeoris.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Services
{
    public class MovimientosServices: IMovimientosServices
    {
        private readonly IMovimientosRepository movimientosRepository;
        private readonly ICuentasRepository cuentasRepository;


        public MovimientosServices(IMovimientosRepository _movimientosRepository, ICuentasRepository _cuentasRepository)
        {
            movimientosRepository = _movimientosRepository;
            cuentasRepository = _cuentasRepository;
        }

        public async Task<ApiResponse> GetMovimientos()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                List<Movimientos> movimientos = movimientosRepository.GetMovimientos().Result;
                response.StatusCode = HttpStatusCode.OK.GetHashCode();
                response.Data = movimientos;
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ApiResponse> AddMovimiento(Movimientos movimiento)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                movimiento.Fecha = DateTime.Now;
                Cuentas cuenta = cuentasRepository.GetCuentaById(movimiento.CuentaId).Result;
                if(cuenta == null)
                {
                    response.Errors.Add(new Error(HttpStatusCode.BadRequest.GetHashCode().ToString(), "No se encontro Numero de cuenta"));
                    return response;
                }
                switch (movimiento.TipoMovimiento.ToLower())
                {
                    case "retiro":
                        if(cuenta.SaldoInicial >= movimiento.Valor)
                            movimiento.Saldo = cuenta.SaldoInicial - movimiento.Valor;
                        else
                        {
                            response.Errors.Add(new Error(HttpStatusCode.BadRequest.GetHashCode().ToString(), "Saldo insuficiente"));
                            return response;
                        }
                        break;
                    case "deposito":
                         movimiento.Saldo = cuenta.SaldoInicial + movimiento.Valor;
                        break;
                    default:
                        response.Errors.Add(new Error(HttpStatusCode.BadRequest.GetHashCode().ToString(), "Tipo de movimiento no existe"));
                        return response;
                }
                bool resultcuenta = cuentasRepository.UpdateCuenta(cuenta).Result;
                bool result = false;
                if(resultcuenta)
                    result = movimientosRepository.AddMovimiento(movimiento).Result;
                else
                {
                    response.Errors.Add(new Error(HttpStatusCode.BadRequest.GetHashCode().ToString(), "Error al realizar la transaccion"));
                }
                
                response.StatusCode = result ? HttpStatusCode.OK.GetHashCode() : HttpStatusCode.InternalServerError.GetHashCode();
                response.Data = result;
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ApiResponse> UpdateMovimiento(Movimientos movimiento)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                bool result = movimientosRepository.UpdateMovimiento(movimiento).Result;
                response.StatusCode = result ? HttpStatusCode.OK.GetHashCode() : HttpStatusCode.InternalServerError.GetHashCode();
                response.Data = result;
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ApiResponse> DeleteMovimiento(int movimientoId)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                bool result = movimientosRepository.DeleteMovimiento(movimientoId).Result;
                response.StatusCode = result ? HttpStatusCode.OK.GetHashCode() : HttpStatusCode.InternalServerError.GetHashCode();
                response.Data = result;
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ApiResponse> Reporte(string startDate, string endDate, string identificacion)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                string format = "dd-MM-yyyy";
                DateTime StartDate = DateTime.ParseExact(startDate,format,CultureInfo.InvariantCulture );
                DateTime EndDate = DateTime.ParseExact(endDate, format, CultureInfo.InvariantCulture);
                List<Movimientos> movimientos = movimientosRepository.GetEstadoCuenta(StartDate, EndDate, identificacion).Result;
                List<ReporteResponse> listReportes = new List<ReporteResponse>();
                foreach (var item in movimientos)
                {
                    ReporteResponse reporte = new ReporteResponse()
                    {
                        Cliente = item.Cuenta.Cliente.Persona.Nombre,
                        Estado = item.Cuenta.Estado,
                        Fecha = item.Fecha,
                        Movimiento = item.Valor,
                        NumeroCuenta = item.CuentaId,
                        SaldoDisponible = item.Cuenta.SaldoInicial - item.Valor,
                        SaldoInicial = item.Cuenta.SaldoInicial,
                        Tipo = item.Cuenta.TipoCuenta
                    };
                    listReportes.Add( reporte );
                }
                response.StatusCode = HttpStatusCode.OK.GetHashCode();
                response.Data = listReportes;
            }
            catch (Exception e)
            {

                throw;
            }
            return response;
        }
    }
}
