using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentaVehiculos_Api.Domain.Models
{
    [Table("Clientes")]
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

  

        public string? Nombre { get; set; }
  
        public string? Apellido { get; set; }
      
        public string? Dpi { get; set; }


    }
}
