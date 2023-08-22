using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class Unidad
    {
        public int Id { get; set; }
        public int IdUnidad { get; set;}
        public int IdHistorial { get; set; }
        public string? NumeroEconomico { get; set; }
        public string? Serie { get; set; }
        public int ModeloAnio { get; set; }
        public string? Placas { get; set; }
        public int Asientos { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<UnidadOperador>? UnidadOperadores { get; set; }
    }
}
