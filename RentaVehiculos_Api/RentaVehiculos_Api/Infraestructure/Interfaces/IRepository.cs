using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Domain.Models;

namespace RentaVehiculos_Api.Infraestructure.Interfaces
{
    public interface IRepository
    {
        Task<List<ClienteReadDTO>> ObtenerClientes();
        Task<Clientes> ObtenerId(int id);
        Task<int> NewCliente(ClienteCreateDTO newCliente);
        Task<ClienteReadDTO> UpdateCliente(int id, ClienteUpdateDTO updateC);
        Task<int> DeleteCliente(int id);
    }
}
