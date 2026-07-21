namespace RentaVehiculos_Api.Domain.Models
{
    public class Rentas_View
    {

            public int RentaId { get; set; }

            public int UserId { get; set; }
            public string? Nombre { get; set; }

            public int VehiculoId { get; set; }
            public string? ModeloVehiculo { get; set; }
            public string? MarcaVehiculo { get; set; }

            public string? Estado_Renta { get; set; }

            public DateTime? Fecha_Inicio { get; set; }
            public DateTime? Fecha_Fin { get; set; }
            public DateTime? Fecha_Fin_Real { get; set; } 

            public decimal? TotalEstimado { get; set; }
            public decimal? TotalFinal { get; set; }
        }
   
}
