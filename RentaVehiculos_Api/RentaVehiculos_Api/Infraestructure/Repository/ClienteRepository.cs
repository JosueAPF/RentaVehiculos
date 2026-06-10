using Microsoft.Data.SqlClient;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Domain.Models;
using RentaVehiculos_Api.Infraestructure.Data;
using RentaVehiculos_Api.Infraestructure.Interfaces;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;

namespace RentaVehiculos_Api.Infraestructure.Repository
{
    public class ClienteRepository: IRepository
    {
        private readonly DataAcces _context;

        public ClienteRepository(DataAcces acces)
        {
            _context = acces;         
        }

        public async Task<List<ClienteReadDTO>>ObtenerClientes() { 
            var misClientes = new List<ClienteReadDTO>();
            using var conn = _context.GetConnection();
            using var cmd = new SqlCommand("select * from Clientes", conn);
            await conn.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync()) {
                var cliente = new Clientes
                {
                    ClienteId = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Apellido = reader.GetString(2),
                    Dpi = reader.GetString(3)
                };

                var dtoMap = new ClienteReadDTO { 
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Dpi = cliente.Dpi
                };

                misClientes.Add(dtoMap);
            }
            return misClientes;
        }
    }
}
