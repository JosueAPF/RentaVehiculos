using System.Text.Json.Serialization;

namespace RentaVehiculos_Api.Aplication.DTOs
{
    public class UserRoleReadDTO
    {
        public int UserId { get; set; }
        public string? Name { get; set; }

        public List<string> Role { get; set; } = new();
    }
}
