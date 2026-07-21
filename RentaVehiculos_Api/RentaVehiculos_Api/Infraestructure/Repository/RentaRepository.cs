using Microsoft.Data.SqlClient;
using RentaVehiculos_Api.Domain.Models;
using RentaVehiculos_Api.Infraestructure.Data;
using RentaVehiculos_Api.Infraestructure.Interfaces;
using System.Data;

namespace RentaVehiculos_Api.Infraestructure.Repository
{
    public class RentaRepository: IRentaRepository
    {
        private readonly DataAcces _dbcontext;

        public RentaRepository(DataAcces context)
        {
            _dbcontext = context;
        }

        public async Task<bool> nuevaRenta(Rentas_SP renta) { 
            using var conn = _dbcontext.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand("sp_RentaInicial", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClienteId", renta.ClienteId);
            cmd.Parameters.AddWithValue("@VehiculoId", renta.VehiculoId);
            cmd.Parameters.AddWithValue("@FechaInicio", renta.FechaInicio);
            await cmd.ExecuteNonQueryAsync();
            return true;
        }

        public async Task<List<Rentas_View>> VerRentas() { 
            var ListadoRentas = new List<Rentas_View>();
            using var conn = _dbcontext.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand("select * from [dbo].[VW_RentaVehiculo]", conn);

            using var result = await cmd.ExecuteReaderAsync();
            while (await result.ReadAsync()) {
                var renta_actual = new Rentas_View
                {
                    RentaId = result.GetInt32(0),
                    UserId = result.GetInt32(1),
                    Nombre = result.GetString(2),
                    VehiculoId = result.GetInt32(3),
                    ModeloVehiculo = result.GetString(4),
                    MarcaVehiculo = result.GetString(5),
                    Estado_Renta = result.GetString(6),
                    Fecha_Inicio = result.IsDBNull(7) ? null: result.GetDateTime(7),
                    Fecha_Fin = result.IsDBNull(8) ? null: result.GetDateTime(8),
                    Fecha_Fin_Real = result.IsDBNull(9) ? null : result.GetDateTime(9),
                    TotalEstimado = result.IsDBNull(10) ? null : result.GetDecimal(10),
                    TotalFinal = result.IsDBNull(11) ? null : result.GetDecimal(11),
                  
                };
                ListadoRentas.Add(renta_actual);
            }

            return ListadoRentas;   



        }


        public async Task<bool> Finalizar_Renta(Rentas_SP_Finalizar renta) {
            using var conn = _dbcontext.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand("SP_FinalizarRenta", conn);
            cmd.CommandType = CommandType.StoredProcedure;

    
            cmd.Parameters.AddWithValue("@IdRenta", renta.IdRenta);
            cmd.Parameters.AddWithValue("@fechaFin_real", renta.FechaFin_Renta);
            /*para el descuento*/
            await cmd.ExecuteNonQueryAsync();
            return true;
        }

    }
}
