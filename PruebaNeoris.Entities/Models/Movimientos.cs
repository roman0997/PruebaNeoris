using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaNeoris.Entities.Models
{
    public class Movimientos
    {
        [Key]
        [Required]
        public int MovimientoId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Supera la longitud permitida.")]
        public string TipoMovimiento { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public decimal Saldo { get; set; }

        [Required]
        [ForeignKey("Cuenta")]
        [StringLength(20, ErrorMessage = "Supera la longitud permitida.")]
        public string CuentaId { get; set; }
        public Cuentas Cuenta { get; set; }
    }
}
