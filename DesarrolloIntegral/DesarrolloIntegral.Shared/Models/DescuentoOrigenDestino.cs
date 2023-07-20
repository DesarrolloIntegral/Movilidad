using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class DescuentoOrigenDestino
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public int Estado { get; set; }

        public int DescuentoDetalleId { get; set; }
        public DescuentoDetalle? DescuentoDetalle { get; set; }

        public int PuntoOrigenId { get; set; }
        public int PuntoDestinoId { get; set; }

        public PuntoRecorrido? PuntoOrigen { get; set; }
        public PuntoRecorrido? PuntoDestino { get; set; }
    }
}
