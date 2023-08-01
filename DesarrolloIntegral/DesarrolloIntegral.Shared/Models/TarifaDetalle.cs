using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class TarifaDetalle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaFin { get; set; }
        public int Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Decimal Precio { get; set; }

        public int PuntoOrigenId { get; set; }
        public PuntoRecorrido? PuntoOrigen { get; set; }
        public int PuntoDestinoId { get; set; }
        public PuntoRecorrido? PuntoDestino { get; set; }
        public int TarifaId { get; set; }
        public Tarifa? Tarifa { get; set; }
    }
}
