using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesarrolloIntegral.Shared.Models
{
    public class Personal
    {
        public int Id { get; set; }

        [Display(Name = "Clave del Empleado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(5, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]

        public string? Clave { get; set; }

        [Display(Name = "Nombre del Empleado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]

        public string? Nombre { get; set; }
        public int Estado { get; set; }

        [Display(Name = "Puesto del Empleado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public int PuestoId { get; set; }
        public Puesto? Puesto { get; set; }

        public virtual ICollection<UnidadOperador>? UnidadOperadores { get; set; }
        public virtual ICollection<Itinerario>? Itinerarios { get; set; }
    }
}
