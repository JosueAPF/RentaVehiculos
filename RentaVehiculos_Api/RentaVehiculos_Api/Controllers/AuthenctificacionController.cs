using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Aplication.Services;
using RentaVehiculos_Api.Domain.RoleModels;

namespace RentaVehiculos_Api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenctificacionController : ControllerBase
    {
        private readonly AuthService _service;

        public AuthenctificacionController(AuthService service)
        {
            _service = service;
        }
       

        [HttpPost("Loggin")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] UserCreateDto dto) {
            var LoginUser = new User { 
                UsuarioId = dto.UsuarioId,
                Name = dto.Name,    
                pass = dto.pass,
               
            };
            Console.WriteLine("Api :"+LoginUser.ToString());
            var login = await _service.Login(LoginUser);
            return Ok(login);
        }

        [HttpGet("GetRoles")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ObtenerUserRoles() {
            var verUserRoles = await _service.ObtenerUserRole();
            return Ok(verUserRoles);
        
        }

        [HttpGet("name")]
        public async Task<ActionResult> ObtenerxNombre(string name) {
            var user = await _service.ObtenerXNombre(name);
            return Ok(user);
        }

        //api exclusivamente para crear usuarios
        [HttpPost("CreateUsers")]
        public async Task<ActionResult> CrearUsuario([FromBody]UserCreateDto dto) {
            var newUsuario = await _service.Crear_Usuario(dto);
            return CreatedAtAction(nameof(ObtenerxNombre), new { name = dto.Name }, newUsuario);
        }

        //api exclusivamente para crear usuarios
        [HttpPost("CreateAdmin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CrearAdmin([FromBody] UserCreateDto dto)
        {
            var newUsuario = await _service.Crear_Admin(dto);
            return CreatedAtAction(nameof(ObtenerxNombre), new { name = dto.Name }, newUsuario);
        }

        //obtener los roles segun el id de usuario
        [HttpGet("Rol/{id}")]
        public async Task<ActionResult> GetmyRol(int id) {
            var obtenerRol = await _service.GetRole_userId(id);
            return Ok(obtenerRol);  
        }
    }
}
