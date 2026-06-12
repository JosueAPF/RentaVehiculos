using RentaVehiculos_Api.Aplication.DTOs;

namespace RentaVehiculos_Api.Infraestructure.Interfaces
{
    public interface IVehiculosRopository
    {
        Task<List<VehiculoReadDTO>> ObtenerVehiuclos();
    }
}
