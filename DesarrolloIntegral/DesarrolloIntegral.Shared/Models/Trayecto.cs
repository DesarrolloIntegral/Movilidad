namespace DesarrolloIntegral.Shared.Models
{
    public class Trayecto
    {
        public int Id { get; set; }

        public int Tipo { get; set; } //0:Salida    1: Paso   2:LLegada

        public int Posicion { get; set; }

        public int Terminal { get; set; } //0:Si  1: No

        public int Kilometros { get; set; }

        public int Minutos { get; set; }

        public int Estancia { get; set; }

        public int Estado { get; set; }

        public int PuntoId { get; set; }
        public PuntoRecorrido? Punto { get; set; }

        public int RutaId { get; set; }
        public Ruta? Ruta { get; set; }
    }
}
