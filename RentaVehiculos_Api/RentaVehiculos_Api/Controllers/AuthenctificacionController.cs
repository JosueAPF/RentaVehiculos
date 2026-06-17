using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Aplication.Services;

namespace RentaVehiculos_Api.Controllers
{
    [AllowAnonymous]
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
        public async Task<ActionResult> Login([FromBody] UserCreateDto dto) {
            var login = await _service.Login(dto);
            return Ok(login);
        }

        [HttpGet]
        [Authorize(Roles = "Cliente")]
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
    }
}
