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

        public string GenerarToken(User user,List<string>Roles) {
            //crear una lista de tipo Claim
            var misclaims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier,user.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, user.Name!)
            };
            //claims de Roles
            foreach (var rol in Roles)
            {

                misclaims.Add(new Claim(ClaimTypes.Role, rol));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: _config["jwt:Issuer"],
                    audience: _config["jwt:Audience"],
                    claims: misclaims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        
      
    }
}
