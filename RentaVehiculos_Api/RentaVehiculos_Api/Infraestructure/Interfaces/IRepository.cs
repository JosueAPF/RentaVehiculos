using RentaVehiculos_Api.Aplication.DTOs;

namespace RentaVehiculos_Api.Infraestructure.Interfaces
{
    public interface IRepository
    {
        Task<List<ClienteReadDTO>> ObtenerClientes();
    }
}
