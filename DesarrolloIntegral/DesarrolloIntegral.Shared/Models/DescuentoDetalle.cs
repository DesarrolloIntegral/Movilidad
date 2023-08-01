using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class DescuentoDetalle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Tipo { get; set; } //Tipo 1 : Valor    2 : Porcentaje

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Valor { get; set; } 

        public int Estado { get; set; }

        public int LineaId { get; set; }
        public virtual Linea? Linea { get; set; }

        public int DescuentoId { get; set; }

        public virtual Descuento? Descuento { get; set; }

        public ICollection<DescuentoOrigenDestino>? OrigenDestinos { get; set; }
    }
}