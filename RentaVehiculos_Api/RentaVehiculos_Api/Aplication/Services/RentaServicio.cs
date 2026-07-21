using Microsoft.Data.SqlClient;
using RentaVehiculos_Api.Aplication.Interfaces;
using RentaVehiculos_Api.Domain.Models;
using RentaVehiculos_Api.Infraestructure.Interfaces;

namespace RentaVehiculos_Api.Aplication.Services
{
    public class RentaServicio:IRentaServicio
    {
        private readonly IRentaRepository _rentas;

        public RentaServicio(IRentaRepository renta)
        {
            _rentas = renta;
        }

        public async Task<bool> NevaRenta(Rentas_SP renta) {
          

            try
            {
                var mi_renta = await _rentas.nuevaRenta(renta);
                if (renta == null)
                {
                    return false;
                }
                return mi_renta;


            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error en la base de datos", e);

            }
            catch (Exception e) {

                throw new ApplicationException("Error al acceder a la base de datos", e);
            }

        }


        public async Task<bool> Finalizacion_renta(Rentas_SP_Finalizar renta) {
           
            try
            {
                var fin_renta = await _rentas.Finalizar_Renta(renta);
                if (renta == null)
                {
                    return false;
                }
                return fin_renta;
              

            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error en la base de datos", e);

            }
            catch (Exception e)
            {

                throw new ApplicationException("Error al acceder a la base de datos", e);
            }
        }

        public async Task<List<Rentas_View>> Mostrar_Rentas() { 
            return await _rentas.VerRentas();
        }
    }
}
