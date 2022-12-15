using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Entities.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
        [ForeignKey("Persona")]
        public string PersonaId { get; set; }
        public Personas Persona { get; set; }
    }
}
