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
    }
}
