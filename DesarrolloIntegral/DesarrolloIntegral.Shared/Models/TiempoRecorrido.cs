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
        public int Estado { get; set; }

        public int HorarioServicioId { get; set; }
        public HorarioServicio? HorarioServicio { get; set; }
        public int TrayectoId { get; set; }
        public Trayecto? Trayecto { get; set; }
    }
}
