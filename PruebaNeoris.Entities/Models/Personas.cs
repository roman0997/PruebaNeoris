using PruebaNeoris.Entities.Resources;
using System.ComponentModel.DataAnnotations;

namespace PruebaNeoris.Entities.Models
{
    public class Personas
    {
        [Key]
        [Required]
        [StringLength(20, ErrorMessage = "Supera la longitud permitida.")]
        public string Identificacion { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Supera la longitud permitida.")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Supera la longitud permitida.")]
        public string Genero { get; set; }

        [Required]
        public int Edad { get; set; }

        [StringLength(100, ErrorMessage = "Supera la longitud permitida.")]
        public string Direccion { get; set; }

        [StringLength(15, ErrorMessage = "Supera la longitud permitida.")]
        public string Telefono { get; set; }
    }
}
