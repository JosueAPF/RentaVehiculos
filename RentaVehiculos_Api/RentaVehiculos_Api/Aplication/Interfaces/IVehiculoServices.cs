using RentaVehiculos_Api.Aplication.DTOs;

namespace RentaVehiculos_Api.Aplication.Interfaces
{
    public interface IVehiculoServices
    {

        Task<List<VehiculoReadDTO>> obtenerVehiuclos();
        Task<VehiculoReadDTO> ObtenerId(int id);
        Task<int> CantidadVehiculos();
    }
}
