using System.ComponentModel.DataAnnotations;

namespace DesarrolloIntegral.Shared.Models
{
    public class Tarifa
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la tarifa")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaFin { get; set; }
        public int Estado { get; set; }

        public int LineaId { get; set; }
        public Linea? Linea { get; set; }
    }
}
