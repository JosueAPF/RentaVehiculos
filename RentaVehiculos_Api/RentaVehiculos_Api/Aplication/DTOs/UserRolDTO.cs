using RentaVehiculos_Api.Domain.RoleModels;

namespace RentaVehiculos_Api.Aplication.DTOs
{
    public class UserRolDTO
    {
        public int UsuarioId { get; set; }
        public string? Name { get; set; }
        public string? pass { get; set; }
        public List<Roles> Roles { get; set; } = new();
    }
}
