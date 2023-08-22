using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloIntegral.Shared.Models
{
    public class UnidadOperador
    {
        public int Id { get; set; }
        public int Estado { get; set; }
        public int UnidadId { get; set; }
        public Unidad? Unidad { get; set; }
        public int PersonalId { get; set; }
        public Personal? Personal { get; set; }
        public int LineaId { get; set; }
        public Linea? Linea { get; set; }
    }
}
