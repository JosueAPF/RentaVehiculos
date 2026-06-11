using Microsoft.Data.SqlClient;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Aplication.Interfaces;
using RentaVehiculos_Api.Domain.Models;
using RentaVehiculos_Api.Infraestructure.Interfaces;


namespace RentaVehiculos_Api.Aplication.Services
{
    public class ClientesServices : IClientesServices
    {
        private readonly IRepository _repo;

        public ClientesServices(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ClienteReadDTO>> verClientes() {
            return await _repo.ObtenerClientes();
        }

        public async Task<Clientes> obtenerClienteId(int id) {
            
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser mayor a 0");
            }

            try
            {
                var client = await _repo.ObtenerId(id);
                if (client == null)
                {

                    throw new KeyNotFoundException("Cliente no encontrado");
                }
                return client;

            }
            catch (SqlException ex)
            {
                // Error de base de datos
                throw new ApplicationException("Error al acceder a la base de datos", ex);

            }
            catch (Exception ex) {
                //error general
                throw new ApplicationException("Ocurrió un error inesperado", ex);
            }
        }
        public async Task<int> CrearClientes(ClienteCreateDTO dto)
        {
            try
            {
                var client = await _repo.NewCliente(dto);
               
                return client;

            }
            catch (SqlException ex)
            {
                // Error de base de datos
                throw new ApplicationException("Error al acceder a la base de datos", ex);

            }
            catch (Exception ex)
            {
                //error general
                throw new ApplicationException("Ocurrió un error inesperado", ex);
            }

        }

        public async Task<ClienteReadDTO> UpdateCliente(int id, ClienteUpdateDTO entity) {

            if (id <= 0 && entity == null) { 
                throw  new ArgumentException("No sea Pendejo!");
            }
            var cliente_update = await _repo.UpdateCliente(id, entity);

            return cliente_update;
            
        }

        public async Task<int> DelCliente(int id) {
            try {
                var deleteC = await _repo.DeleteCliente(id);
                return deleteC;


            }
            catch (SqlException ex)
            {
                // Error de base de datos
                throw new ApplicationException("Error al acceder a la base de datos", ex);

            }
            catch (Exception ex)
            {
                //error general
                throw new ApplicationException("Ocurrió un error inesperado", ex);
            }

        }
    }
}
