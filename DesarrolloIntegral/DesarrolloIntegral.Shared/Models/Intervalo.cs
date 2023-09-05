namespace DesarrolloIntegral.Shared.Models
{
    public class Intervalo
    {
        public int Id { get; set; }
        public DateTime HorarioSalida { get; set; } //Hora Salida
        public DateTime HorarioLlegada { get; set; } //Hora Llegada
        public int Sentido { get; set; } //1:ida 2:regreso
        public int Dias { get; set; } //Dias en que tarda en llegar al punto de recorrido parcial
        public int Estado { get; set; }
        public int IdRecorrido { get; set; }

        public int ItinerarioId { get; set; }
        public Itinerario? Itinerario { get; set; }
        public int TrayectoId { get; set; }
        public Trayecto? Trayecto { get; set; }
    }
}
