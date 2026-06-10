using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaVehiculos_Api.Aplication.DTOs;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientId(int id) {
            return Ok(await _services.obtenerClienteId(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] ClienteCreateDTO newClient) { 
            //creamos una instancia de GetId para obtener el id
            var nuevoCliente = await _services.CrearClientes(newClient);
            var cliente = await _services.obtenerClienteId(nuevoCliente);
            return CreatedAtAction(nameof(GetClientId), new {id = cliente.ClienteId },cliente);
        }
    }
}
