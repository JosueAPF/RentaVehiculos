namespace RentaVehiculos_Api.Domain.Models
{
    public class Vehiculos_Disponibles_View
    {
      
            public int Id { get; set; }
            public string Marca { get; set; } = string.Empty;
            public string Modelo { get; set; } = string.Empty;
            public string Placa { get; set; } = string.Empty;
            public string Color { get; set; } = string.Empty;
            public int Anio { get; set; }
            public string Estado { get; set; } = string.Empty;
            public decimal TarifaDiaria { get; set; }
        }
    
}
