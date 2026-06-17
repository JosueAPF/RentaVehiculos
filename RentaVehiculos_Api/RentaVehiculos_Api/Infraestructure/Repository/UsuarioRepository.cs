using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Aplication.Helpers;
using RentaVehiculos_Api.Domain.Models;
using RentaVehiculos_Api.Domain.RoleModels;
using RentaVehiculos_Api.Infraestructure.Data;
using RentaVehiculos_Api.Infraestructure.Interfaces;
using System.Data;
using System.Reflection.PortableExecutable;

namespace RentaVehiculos_Api.Infraestructure.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly DataAcces _acces;
        public UsuarioRepository(DataAcces acces)
        {
            _acces = acces; 
        }

        public async Task<List<UserRoleReadDTO>> ObtenerUserRoles() {
            var miUserRole = new List<UserRoleReadDTO>();
            using var conn = _acces.GetConnection();
            using var cmd = new SqlCommand(@"select U.UsuarioId,U.Name,R.Roles from UserRoles UR "+ 
                                            "inner join [dbo].[User] U on U.UsuarioId = UR.UserId "+
                                            "inner join Roles R on R.RolId = UR.RolesId", conn);
            await conn.OpenAsync();

            using var result = await cmd.ExecuteReaderAsync();

            while (await result.ReadAsync()) {
                var user1 = new UserRoleReadDTO
                {
                     UserId = result.GetInt32(0),
                     Name = result.GetString(1),
                     Role = result.GetString(2) 
                     

                };

                miUserRole.Add(user1);
            }

            return miUserRole;

        }

        public async Task<string> CrearUsuario_RolUsuario(UserCreateDto newUser) {
            var hasher = new PasswordHasher<User>();

            var userEntity = new User
            {
                Name = newUser.Name
            };
            var hashedPassword = hasher.HashPassword(userEntity, newUser.pass);

            using var conn = _acces.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(@"insert into [dbo].[User](Name,Pass)values(@Name,@Pass);SELECT SCOPE_IDENTITY()", conn);


            cmd.Parameters.AddWithValue("@Name", newUser.Name);
            cmd.Parameters.AddWithValue("@Pass", hashedPassword);
           

            var UserId_ = await cmd.ExecuteScalarAsync();
            using var cmd_UserRol = new SqlCommand(@"insert into UserRoles(UserId,RolesId) values(@UserId,3)", conn);//3 es rol Usuario
            cmd_UserRol.Parameters.AddWithValue("@UserId", Convert.ToInt32(UserId_));

            await cmd_UserRol.ExecuteNonQueryAsync();//ejecuta sin retorno la consulta de insert

            return newUser.Name!;

        }

        public async Task<UserReadDTO> ObtenerNombre(string? Name) {
            var usuarioDTO = new UserReadDTO();
            using var conn = _acces.GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand("select * from [dbo].[User] where Name = @Name",conn);

            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.CommandType = CommandType.Text;
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var miUser = new User
                {
                    UsuarioId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    pass = reader.GetString(2),
                    FechaCreacion = reader.GetDateTime(3)
                };
                usuarioDTO = new UserReadDTO { 
                    Name = miUser.Name,
                    pass = miUser.pass,
                    FechaCreacion = miUser.FechaCreacion
                };

            }
            return usuarioDTO;


        }
    }
}
