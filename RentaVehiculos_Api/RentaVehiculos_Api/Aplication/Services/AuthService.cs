using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Aplication.Helpers;
using RentaVehiculos_Api.Domain.RoleModels;
using RentaVehiculos_Api.Infraestructure.Interfaces;

namespace RentaVehiculos_Api.Aplication.Services
{
    public class AuthService
    {
        private readonly IUsuarioRepository _repo;
        private readonly JwtHelper _jwt;
        public AuthService(IUsuarioRepository repo, JwtHelper jwt)
        {
            _repo = repo;
            _jwt = jwt;
        }
        public async Task<UserReadDTO> ObtenerXNombre(string? name) {
            try
            {
                var UserRoles = await _repo.ObtenerNombre(name);
                return UserRoles;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error en la consulta sql!", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error Interno!", ex);
            }
        }

        public async Task<List<UserRoleReadDTO>> ObtenerUserRole() {

            try {
                var UserRoles = await _repo.ObtenerUserRoles();
                return UserRoles;
            } catch (SqlException ex) {
                throw new ApplicationException("Error en la consulta sql!", ex);
            } catch (Exception ex) {
                throw new ApplicationException("Error Interno!", ex);
            }



        }

        public async Task<string> Crear_Usuario(UserCreateDto user) {
            try
            {
                var CreateUser = await _repo.CrearUsuario_RolUsuario(user);
                return CreateUser;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error en la consulta sql!", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error Interno!", ex);
            }
        }

        public async Task<string> Crear_Admin(UserCreateDto user)
        {
            try
            {
                var CreateUser = await _repo.CrearUsuario_RolAdmin(user);
                return CreateUser;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error en la consulta sql!", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error Interno!", ex);
            }
        }

        public async Task<string> Login(User dto)
        {
            if (string.IsNullOrEmpty(dto.Name) || string.IsNullOrEmpty(dto.pass)) {
                return null!;
            }

            var userModel = await _repo.ObtenerNombre(dto.Name);
            var userConvert = new User
            {
                UsuarioId = userModel.UsuarioId,
                Name = userModel.Name,
                pass = userModel.pass,
                FechaCreacion = userModel.FechaCreacion
            };

            Console.WriteLine("Servicio :" + userConvert.ToString());

            var hasher = new PasswordHasher<User>();

            var result = hasher.VerifyHashedPassword(userConvert, userModel.pass!, dto.pass);

            if (result == PasswordVerificationResult.Failed)
                return null!;

            var rolesList = new List<string>();
            var roles = await _repo.GetRoles(userConvert.UsuarioId);
           

            if (roles != null && roles.Role != null)
            {
                rolesList = roles.Role;
            }

            Console.WriteLine("Roles count: " + rolesList.Count);


            return _jwt.GenerarToken(userConvert, rolesList);

        }

        public async Task<UserRoleReadDTO?> GetRole_userId(int id) {
            try
            {
                var getRole = await _repo.GetRoles(id);
                return getRole;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error en la consulta sql!", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error Interno!", ex);
            }
        }

      
    }
}
