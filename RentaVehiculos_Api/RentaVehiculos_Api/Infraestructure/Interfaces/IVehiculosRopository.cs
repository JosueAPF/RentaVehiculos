using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Domain.Models;

namespace RentaVehiculos_Api.Infraestructure.Interfaces
{
    public interface IVehiculosRopository
    {
        Task<List<VehiculoReadDTO>> ObtenerVehiuclos();
        Task<VehiculoReadDTO> BuscarXId(int id);

        Task<int> CantidadVehiculosActuales();

        Task<List<Vehiculos_Disponibles_View>> VehiculosDisponibles();
    }
}
