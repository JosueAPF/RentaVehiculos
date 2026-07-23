using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Domain.Models;

namespace RentaVehiculos_Api.Aplication.Interfaces
{
    public interface IVehiculoServices
    {

        Task<List<VehiculoReadDTO>> obtenerVehiuclos();
        Task<VehiculoReadDTO> ObtenerId(int id);
        Task<int> CantidadVehiculos();
        Task<List<Vehiculos_Disponibles_View>> VerVehiculos_Disponibles();
    }
}
