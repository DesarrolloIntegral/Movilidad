using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesarrolloIntegral.Shared.Models
{
    public class PuntoRecorrido
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Punto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]
        public string? Nombre { get; set; }

        [Display(Name = "Abreviatura del Punto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(5, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]
        public string? Abreviatura { get; set; }
        public int Estado { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
    }
}
