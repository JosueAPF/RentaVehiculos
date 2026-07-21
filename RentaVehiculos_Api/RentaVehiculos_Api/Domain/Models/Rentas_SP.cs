namespace RentaVehiculos_Api.Domain.Models
{
    public class Rentas_SP
    {
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public DateTime FechaInicio {get; set;}
    }
}
