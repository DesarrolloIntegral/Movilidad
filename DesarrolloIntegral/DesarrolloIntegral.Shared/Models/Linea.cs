using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesarrolloIntegral.Shared.Models
{
    public class Linea
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la Linea")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]
        public string? Nombre { get; set; }
        public int Estado { get; set; }

        public ICollection<DescuentoDetalle>? DescuentoDetalles { get; set; }
    }
}
