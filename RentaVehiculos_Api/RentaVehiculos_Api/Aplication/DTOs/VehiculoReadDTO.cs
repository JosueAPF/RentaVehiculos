namespace RentaVehiculos_Api.Aplication.DTOs
{
    public class VehiculoReadDTO
    {
        public int vehiculoId { get; set; }
        public int EstadoVehiculoId { get; set; }
        public string? Placa { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Anio { get; set; }
        public string? Color { get; set; }
        public decimal Tarifa { get; set; }
        public bool Disponible { get; set; }
    }
}
