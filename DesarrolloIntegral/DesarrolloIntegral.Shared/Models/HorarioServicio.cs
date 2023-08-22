using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class HorarioServicio
    {
        public int Id { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFin { get; set; }
        public int Estado { get; set; }

        public int ItinerarioId { get; set; }
        public Itinerario? Itinerario { get; set; }
        public int TrayectoId { get; set; }
        public Trayecto? Trayecto { get; set; }
    }
}
