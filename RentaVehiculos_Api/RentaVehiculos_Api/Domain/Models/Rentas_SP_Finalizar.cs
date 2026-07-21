namespace RentaVehiculos_Api.Domain.Models
{
    public class Rentas_SP_Finalizar
    {
        public int IdRenta { get; set; }

        public DateTime FechaFin_Renta { get; set; }

        /*
         * 
         por si quieres aplicar un descuento
        public decimal Descuento { get; set; }

        */
    }
}
