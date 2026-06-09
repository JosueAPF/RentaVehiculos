using RentaVehiculos_Api.Aplication.DTOs;

namespace RentaVehiculos_Api.Aplication.Interfaces
{
    public interface IClientesServices
    {
        Task<List<ClienteReadDTO>> verClientes();
       
    }
}
