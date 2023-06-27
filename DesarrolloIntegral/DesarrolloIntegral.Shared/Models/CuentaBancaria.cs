using System.ComponentModel.DataAnnotations;

namespace DesarrolloIntegral.Shared.Models
{
    public class CuentaBancaria
    {
        [Key]
        public int IdCuenta { get; set; }
        [Display(Name = "Nombre del Banco")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]
        public string NombreBanco { get; set; } = null!;
        public int NumeroCuenta { get; set; }
        public int EstadoCuenta { get; set; }
    }
}
