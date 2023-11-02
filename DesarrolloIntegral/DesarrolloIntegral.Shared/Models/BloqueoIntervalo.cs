using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class BloqueoIntervalo
    {
        public int Id { get; set; }
        public string? Dia { get; set; } //string dia = DateTime.Now.ToString("dddd");

        public int PuntoId { get; set; }
        public PuntoRecorrido? Punto { get; set; }

        public int IntervaloId { get; set; }
        public Intervalo? Intervalo { get; set; }
    }
}