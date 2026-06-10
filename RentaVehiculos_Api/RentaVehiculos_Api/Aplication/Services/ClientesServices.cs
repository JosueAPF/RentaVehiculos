using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Aplication.Interfaces;
using RentaVehiculos_Api.Infraestructure.Interfaces;


namespace RentaVehiculos_Api.Aplication.Services
{
    public class ClientesServices: IClientesServices
    {
        private readonly IRepository _repo;

        public ClientesServices(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ClienteReadDTO>> verClientes() {
            return await _repo.ObtenerClientes();
        }
    }
}
