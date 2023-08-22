using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class Itinerario
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Estado { get; set; }

        public int RutaId { get; set; } //Ruta a la que se le genera el itinerario
        public Ruta? Ruta { get; set; }

        public virtual ICollection<HorarioServicio>? HorarioServicios { get; set; }
    }
}
