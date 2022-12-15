using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Resources;
using PruebaNeoris.Entities.Response;
using PruebaNeoris.Entities.Utils;
using System.Globalization;
using System.Net;

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
                response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                response.Errors.Add(new Error(HttpStatusCode.InternalServerError.GetHashCode(), MessagesResources.Error));
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
                    response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                    response.Errors.Add(new Error(HttpStatusCode.BadRequest.GetHashCode(), MessagesResources.CuentaNoExiste));
                    return response;
                }
                switch (movimiento.TipoMovimiento.ToLower())
                {
                    case "retiro":
                        if(cuenta.SaldoInicial >= movimiento.Valor)
                            movimiento.Saldo = cuenta.SaldoInicial - movimiento.Valor;
                        else
                        {
                            response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                            response.Errors.Add(new Error(HttpStatusCode.BadRequest.GetHashCode(), MessagesResources.SaldoNoDisponible));
                            return response;
                        }
                        break;
                    case "deposito":
                         movimiento.Saldo = cuenta.SaldoInicial + movimiento.Valor;
                        break;
                    default:
                        response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                        response.Errors.Add(new Error(HttpStatusCode.BadRequest.GetHashCode(), MessagesResources.TipoMovimientoNoExiste));
                        return response;
                }
                bool resultcuenta = cuentasRepository.UpdateCuenta(cuenta).Result;
                bool result = false;
                if(resultcuenta)
                    result = movimientosRepository.AddMovimiento(movimiento).Result;
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                    response.Errors.Add(new Error(HttpStatusCode.BadRequest.GetHashCode(), MessagesResources.ErrorTransaccion));
                }
                
                response.StatusCode = result ? HttpStatusCode.OK.GetHashCode() : HttpStatusCode.InternalServerError.GetHashCode();
                response.Data = result;
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                response.Errors.Add(new Error(HttpStatusCode.InternalServerError.GetHashCode(), MessagesResources.Error));
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
                response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                response.Errors.Add(new Error(HttpStatusCode.InternalServerError.GetHashCode(), MessagesResources.Error));
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
                response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                response.Errors.Add(new Error(HttpStatusCode.InternalServerError.GetHashCode(), MessagesResources.Error));
            }
            return response;
        }

        public async Task<ApiResponse> Reporte(string startDate, string endDate, string identificacion)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                string format = MessagesResources.FormatoFecha;
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
                response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                response.Errors.Add(new Error(HttpStatusCode.InternalServerError.GetHashCode(), MessagesResources.Error));
            }
            return response;
        }
    }
}
