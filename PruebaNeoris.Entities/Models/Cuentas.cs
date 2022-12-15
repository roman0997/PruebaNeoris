using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaNeoris.Entities.Models
{
    public class Cuentas
    {
        [Required]
        [Key]
        [StringLength(20, ErrorMessage = "Supera la longitud permitida.")]
        public string NumeroCuenta { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Supera la longitud permitida.")]
        public string TipoCuenta { get; set; }

        [Required]
        public decimal SaldoInicial { get; set; }

        [Required]
        public bool Estado { get; set; }

        [ForeignKey("Cliente")]
        [Required]
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }
    }
}
