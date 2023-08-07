using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class TarifaOrigen
    {
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public Decimal PrecioOriginal { get; set; }

        public Decimal PrecioNuevo { get; set; }

        public int PuntoOrigenId { get; set; }
        public string? NombreOrigen { get; set; }

        public int PuntoDestinoId { get; set; }
        public string? NombreDestino { get; set; }

    }
}
