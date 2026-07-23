using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Domain.RoleModels;

namespace RentaVehiculos_Api.Infraestructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UserRoleReadDTO>> ObtenerUserRoles();
        Task<string> CrearUsuario_RolUsuario(UserCreateDto newUser);
        Task<UserReadDTO> ObtenerNombre(string? Name);
        Task<UserRoleReadDTO?> GetRoles(int userId);

        Task<string> CrearUsuario_RolAdmin(UserCreateDto newUser);
    }
}
