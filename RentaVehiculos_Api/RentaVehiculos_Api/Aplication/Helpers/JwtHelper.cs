using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Domain.RoleModels;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentaVehiculos_Api.Aplication.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _config;

        public JwtHelper(IConfiguration config)
        {
            _config = config;   
        }

        public string GenerarToken(User user) {
            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier,user.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: _config["jwt:Issuer"],
                    audience: _config["jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        
      
    }
}
