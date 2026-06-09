using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaVehiculos_Api.Aplication.Interfaces;

namespace RentaVehiculos_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesServices _services;
        public ClientesController(IClientesServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes() {
            return Ok(await _services.verClientes());
        }
    }
}
