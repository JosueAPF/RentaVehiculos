using System.Text.Json.Serialization;

namespace RentaVehiculos_Api.Aplication.DTOs
{
    public class UserReadDTO
    {
        [JsonIgnore]
        public int UsuarioId { get; set; }
        public string? Name { get; set; }
        public string? pass { get; set; }

        public DateTime FechaCreacion { get; set; }


        public override string ToString()
        {
            return $"{UsuarioId},{Name}";
        }
    }
}
