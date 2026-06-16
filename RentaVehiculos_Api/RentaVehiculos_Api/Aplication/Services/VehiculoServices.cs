using Microsoft.Data.SqlClient;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Aplication.Interfaces;
using RentaVehiculos_Api.Infraestructure.Interfaces;

namespace RentaVehiculos_Api.Aplication.Services
{
    public class VehiculoServices: IVehiculoServices
    {
        private readonly IVehiculosRopository _repo;
        public VehiculoServices(IVehiculosRopository repo)
        {
            _repo = repo;   
        }

        public async Task<List<VehiculoReadDTO>> obtenerVehiuclos() {
            try
            {
                var misVehiculos = await _repo.ObtenerVehiuclos();
                return misVehiculos;

            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error Accesos a la Base de datos!",ex);
            }
            catch (Exception ex) {
                throw new ApplicationException("Error Inesperado", ex);
            }

        }

        public async Task<VehiculoReadDTO> ObtenerId(int id) {
            if (id == null) {
                throw new ApplicationException("Error inserte un ID");
            }

            try
            {
                var misVehiculos = await _repo.BuscarXId(id);
                return misVehiculos;

            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error Accesos a la Base de datos!", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error Inesperado", ex);
            }
        }

        public async Task<int> CantidadVehiculos() {
            try
            {
                var misVehiculos = await _repo.CantidadVehiculosActuales();
                return misVehiculos;

            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error Accesos a la Base de datos!", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error Inesperado", ex);
            }
        }
    }
}
