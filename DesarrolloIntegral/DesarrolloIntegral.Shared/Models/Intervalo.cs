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
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }

        public int ItinerarioId { get; set; }
        public Itinerario? Itinerario { get; set; }
        public int TrayectoId { get; set; }
        public Trayecto? Trayecto { get; set; }
    }
}
