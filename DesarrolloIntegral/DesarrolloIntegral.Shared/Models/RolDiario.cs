namespace DesarrolloIntegral.Shared.Models
{
    public class RolDiario
    {
        public int Id { get; set; }
        public DateTime FechaRol { get; set; }
        public int Estado { get; set; }

        public int ItinerarioId { get; set; }
        public Itinerario? Itinerario { get; set; }

        public virtual ICollection<Viaje>? Viajes { get; set; }
    }
}