using RentaVehiculos_Api.Aplication.DTOs;

namespace RentaVehiculos_Api.Infraestructure.Interfaces
{
    public interface IVehiculosRopository
    {
        Task<List<VehiculoReadDTO>> ObtenerVehiuclos();
        Task<VehiculoReadDTO> BuscarXId(int id);

        Task<int> CantidadVehiculosActuales();
    }
}
