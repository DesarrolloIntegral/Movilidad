namespace DesarrolloIntegral.Shared.Models
{
    public class EventoViaje
    {
        public int Id { get; set; }
        public DateTime FechaHoraEvento { get; set; }
        public int Tipo { get; set; } //1:Salida    2:Paso   3:Llegada
        public int Estado { get; set; } //1:Programada   2:En Ruta    3:Terminada  0:Cancelada

        public int PuntoRecorridoId { get; set; }
        public PuntoRecorrido? PuntoRecorrido { get; set; }

        public int ViajeId { get; set; }
        public Viaje? Viaje { get; set; }
        public int UnidadId { get; set; }
        public Unidad? Unidad { get; set; }
    }
}