using Microsoft.Data.SqlClient;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Domain.Models;
using RentaVehiculos_Api.Infraestructure.Data;
using RentaVehiculos_Api.Infraestructure.Interfaces;
using System.Data;

namespace RentaVehiculos_Api.Infraestructure.Repository
{
    public class VehiculosRepository:IVehiculosRopository
    {
        private readonly DataAcces _dataAcces;

        public VehiculosRepository(DataAcces acces)
        {
            _dataAcces = acces;    
        }

        public async Task<List<VehiculoReadDTO>> ObtenerVehiuclos() { 
            var misVehiculos = new List<VehiculoReadDTO>();
            using var conn = _dataAcces.GetConnection();
            using var cmd = new SqlCommand("Select * from Vehiculos", conn);
            await conn.OpenAsync();
            cmd.CommandType = CommandType.Text;

            using var reader = cmd.ExecuteReader();
            while (await reader.ReadAsync()) {
                var vehiculos = new Vehiculos { 
                    vehiculoId = reader.GetInt32(0),
                    EstadoVehiculoId = reader.GetInt32(1),
                    Placa = reader.GetString(2),
                    Marca = reader.GetString(3),
                    Modelo = reader.GetString(4),
                    Anio = reader.GetInt32(5),
                    Color = reader.GetString(6),
                    Tarifa = reader.GetDecimal(7),
                    Disponible = reader.GetBoolean(8)
                };
                var dto = new VehiculoReadDTO {
                    vehiculoId = vehiculos.vehiculoId,
                    EstadoVehiculoId = vehiculos.EstadoVehiculoId,
                    Placa = vehiculos.Placa,
                    Marca = vehiculos.Marca,
                    Modelo = vehiculos.Modelo,
                    Anio = vehiculos.Anio,
                    Color = vehiculos.Color,
                    Tarifa = vehiculos.Tarifa,
                    Disponible = vehiculos.Disponible

                };
                misVehiculos.Add(dto);
            }
            return misVehiculos;

        }

    }
}
