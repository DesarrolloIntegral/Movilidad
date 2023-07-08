using System.ComponentModel.DataAnnotations;

namespace DesarrolloIntegral.Shared.Models
{
    public class Puesto
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Puesto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]

        public string? Nombre { get; set; }
        public int Estado { get; set; }

        public ICollection<Personal>? Personals { get; set; }
    }
}
