using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class DescuentoDetalle
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Tipo { get; set; }
        public decimal Valor { get; set; }

        public int Estado { get; set; }

        public int LineaId { get; set; }
        public Linea? Linea{ get; set; }

        public Descuento? Descuento { get; set; }
        public int DescuentoId { get; set; }

        public ICollection<DescuentoOrigenDestino>? OrigenDestinos { get; set; }
    }
}
