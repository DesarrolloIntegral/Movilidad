namespace DesarrolloIntegral.Shared.Models
{
    public class Trayecto
    {
        public int Id { get; set; }

        public int Tipo { get; set; } //1:Salida    2: Paso   3:LLegada

        public int Posicion { get; set; }

        public int Terminal { get; set; } //1:Si  2: No

        public decimal Kilometros { get; set; }

        public int Minutos { get; set; }

        public int Estancia { get; set; }

        public int Estado { get; set; }

        public int PuntoId { get; set; }
        public PuntoRecorrido? Punto { get; set; }

        public int RutaId { get; set; }
        public Ruta? Ruta { get; set; }
    }
}
