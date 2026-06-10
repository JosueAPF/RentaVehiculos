using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Domain.Models;

namespace RentaVehiculos_Api.Aplication.Interfaces
{
    public interface IClientesServices
    {
        Task<List<ClienteReadDTO>> verClientes();
        Task<Clientes> obtenerClienteId(int id);
        Task<int> CrearClientes(ClienteCreateDTO dto);
    }
       
}
