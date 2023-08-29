using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class TiempoRecorrido
    {
        public int Id { get; set; }
        public int Minutos { get; set; }
        public int Sentido { get; set; }   //1: Ida   2: Regreso
        public int Estado { get; set; }

        public int ItinerarioId { get; set; }
        public Itinerario? Itinerario { get; set; }
        public int TrayectoId { get; set; }
        public Trayecto? Trayecto { get; set; }
    }
}
