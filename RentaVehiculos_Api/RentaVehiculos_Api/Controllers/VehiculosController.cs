using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaVehiculos_Api.Aplication.DTOs;
using RentaVehiculos_Api.Aplication.Interfaces;

namespace RentaVehiculos_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoServices _servicio;

        public VehiculosController(IVehiculoServices servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<VehiculoReadDTO>>> GetAllVehiculos() {
            var obtenerVehiculos = await _servicio.obtenerVehiuclos();
            return obtenerVehiculos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoReadDTO>> GetById(int id) {
            var busquedaxId = await _servicio.ObtenerId(id);
            return Ok(busquedaxId);
        }

        [HttpGet("CantidadVehiculos")]
        public async Task<ActionResult> CountVehiculos() {
            var cantidadVehiculos = await _servicio.CantidadVehiculos();
            return Ok(cantidadVehiculos);
        }
        
    }
}
