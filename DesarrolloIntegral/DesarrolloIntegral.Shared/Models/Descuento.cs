using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DesarrolloIntegral.Shared.Models
{
    public class Descuento
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del descuento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]
        public string? Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Estado { get; set; }

        public ICollection<DescuentoDetalle>? DescuentoDetalles { get; set; }
    }
}
