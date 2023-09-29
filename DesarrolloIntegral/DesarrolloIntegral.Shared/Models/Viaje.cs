namespace DesarrolloIntegral.Shared.Models
{
    public class Viaje
    {
        public int Id { get; set; }
        public int IdRecorrido { get; set; }
        public int KmsRecorrido { get; set; }
        public int Sentido { get; set; }
        public DateTime FechaCaptura { get; set; }
        public DateTime FechaHoraOficial { get; set; }
        public int Estado { get; set; }  //1:Programada   2:En Ruta    3:Terminada  0:Cancelada

        public int Operador1Id { get; set; }
        public Personal? Operador1 { get; set; }
        public int Operador2Id { get; set; }
        public Personal? Operador2 { get; set; }
        public int RolesDiariosId { get; set; }
        public RolDiario? RolesDiarios { get; set; }
        public int UnidadId { get; set; }
        public Unidad? Unidad { get; set; }

        public virtual ICollection<EventoViaje>? Eventos { get; set; }
    }
}
