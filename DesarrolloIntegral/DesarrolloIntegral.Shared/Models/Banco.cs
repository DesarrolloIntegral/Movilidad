using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class Banco
    {
        [Key]
        public int IdBanco { get; set; }

        [Display(Name = "Nombre del Banco")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres.")]
        public string? NombreBanco { get; set; }
        public int EstadoBanco { get; set; }
    }
}
