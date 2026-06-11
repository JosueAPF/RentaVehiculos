using Microsoft.Data.SqlClient;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Domain.Models;
using RentaVehiculos_Api.Infraestructure.Data;
using RentaVehiculos_Api.Infraestructure.Interfaces;
using System.Data;
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

        public async Task<Clientes> ObtenerId(int id)
        {
            var misClientes = new Clientes();
            using var conn = _context.GetConnection();
            using var cmd = new SqlCommand("select * from Clientes where clienteId = @id ", conn);
            //Agregar parámetro de forma segura
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            await conn.OpenAsync();
            cmd.CommandType = CommandType.Text;
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                misClientes = new Clientes {
                    ClienteId = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Apellido = reader.GetString(2),
                    Dpi = reader.GetString(3)
                };

            }
            return misClientes;
        }
        public async Task<int> NewCliente(ClienteCreateDTO newCliente)
        {
            var misClientes = new List<ClienteCreateDTO>();
            using var conn = _context.GetConnection();
            using var cmd = new SqlCommand("INSERT INTO Clientes (Nombre,Apellido,Dpi) VALUES (@Nombre,@Apellido,@Dpi);SELECT SCOPE_IDENTITY() ", conn);
            await conn.OpenAsync();
            

            cmd.Parameters.AddWithValue("@Nombre", newCliente.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", newCliente.Apellido);
            cmd.Parameters.AddWithValue("@Dpi", newCliente.Dpi);
            var result = await cmd.ExecuteScalarAsync();



            return Convert.ToInt32(result);
        }

        public async Task<ClienteReadDTO> UpdateCliente(int id,ClienteUpdateDTO updateC) {
            var clienteUpdate = new ClienteReadDTO();
            using var conn = _context.GetConnection();
            using var cmd = new SqlCommand("update  Clientes" +
                                           " set Nombre = @Nombre,Apellido = @Apellido,Dpi = @Dpi where clienteId = @id", conn);

            
            await conn.OpenAsync();

            /*asignandole valores a los parametros @*/
            cmd.Parameters.AddWithValue("@Nombre", updateC.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", updateC.Apellido);
            cmd.Parameters.AddWithValue("@Dpi", updateC.Dpi);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            await cmd.ExecuteNonQueryAsync();

            clienteUpdate = new ClienteReadDTO {
                ClienteId = id,
                Nombre = updateC.Nombre,
                Apellido = updateC.Apellido,
                Dpi = updateC.Dpi
            };

            return clienteUpdate;

        }

        public async Task<int> DeleteCliente(int id) {
            using var conn = _context.GetConnection();
            using var cmd = new SqlCommand("delete from Clientes where clienteId = @id", conn);
            await conn.OpenAsync();

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            var result = await cmd.ExecuteNonQueryAsync();

            return Convert.ToInt32(result);
        }
    }
}
