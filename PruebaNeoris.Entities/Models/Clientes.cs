using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaNeoris.Entities.Models
{
    public class Clientes
    {
        public int ClienteId { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Supera la longitud permitida.")]
        public string Contrasena { get; set; }
        
        [Required]
        public bool Estado { get; set; }
        
        [Required]
        [ForeignKey("Persona")]
        [StringLength(20, ErrorMessage = "Supera la longitud permitida.")]
        public string PersonaId { get; set; }
        public Personas Persona { get; set; }
    }
}
