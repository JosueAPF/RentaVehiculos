using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Aplication.Interfaces;
using RentaVehiculos_Api.Infraestructure.Repository;

namespace RentaVehiculos_Api.Aplication.Services
{
    public class ClientesServices: IClientesServices
    {
        private readonly ClienteRepository _repo;

        public ClientesServices(ClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ClienteReadDTO>> verClientes() {
            return await _repo.ObtenerClientes();
        }
    }
}
