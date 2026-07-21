using RentaVehiculos_Api.Domain.Models;

namespace RentaVehiculos_Api.Aplication.Interfaces
{
    public interface IRentaServicio
    {
        Task<bool> NevaRenta(Rentas_SP renta);
        Task<List<Rentas_View>> Mostrar_Rentas();
        Task<bool> Finalizacion_renta(Rentas_SP_Finalizar renta);
    }
}
