using RentaVehiculos_Api.Domain.Models;

namespace RentaVehiculos_Api.Infraestructure.Interfaces
{
    public interface IRentaRepository
    {
        Task<bool> nuevaRenta(Rentas_SP renta);
        Task<List<Rentas_View>> VerRentas();

        Task<bool> Finalizar_Renta(Rentas_SP_Finalizar renta);
    }
}
