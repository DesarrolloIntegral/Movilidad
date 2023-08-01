using System.ComponentModel.DataAnnotations;

namespace DesarrolloIntegral.Shared.Models
{
    public class Ruta
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la Ruta")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]
        public string? Nombre { get; set; }

        [Display(Name = "Codigo de la Ruta")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(7, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]
        public string? Codigo { get; set; }

        public int Estado { get; set; }

        public int LineaId { get; set; }
        public virtual Linea? Linea { get; set; }

        public virtual ICollection<Trayecto>? Trayectos { get; set; }

        [Display(Name = "Kilometros")]
        public decimal KmsTotal => Trayectos == null ? 0 : Trayectos.Sum(k => k.Kilometros);

        [Display(Name = "Minutos")]
        public int MinTotal => Trayectos == null ? 0 : Trayectos.Sum(k => k.Minutos + k.Estancia);
    }
}
