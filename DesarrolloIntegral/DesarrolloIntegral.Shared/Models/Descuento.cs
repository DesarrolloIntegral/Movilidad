namespace DesarrolloIntegral.Shared.Models
{
    public class Descuento
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Estado { get; set; }

        public ICollection<DescuentoDetalle>? DescuentoDetalles { get; set; }
    }
}
