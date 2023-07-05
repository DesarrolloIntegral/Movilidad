using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace DesarrolloIntegral.Shared.Models
{
    public class CuentaBancaria
    {
        public int Id { get; set; }

        [Display(Name = "Número de cuenta")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]
        public string? NumeroCuenta { get; set; }
        public int EstadoCuenta { get; set; }

        public int BancoId { get; set; }
        public Banco? Banco { get; set; }
    }
}
