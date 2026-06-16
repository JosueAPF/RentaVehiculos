using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Aplication.Services;

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

        [HttpGet]
        public async Task<ActionResult> ObtenerUserRoles() {
            var verUserRoles = await _service.ObtenerUserRole();
            return Ok(verUserRoles);
        
        }

        [HttpGet("name")]
        public async Task<ActionResult> ObtenerxNombre(string name) {
            var user = await _service.ObtenerXNombre(name);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CrearUsuario([FromBody]UserCreateDto dto) {
            var newUsuario = await _service.Crear_Usuario(dto);
            return CreatedAtAction(nameof(ObtenerxNombre), new { name = dto.Name }, newUsuario);
        }
    }
}
