using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Entities.Models
{
    public class Cuentas
    {
        [Key]
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }
    }
}
