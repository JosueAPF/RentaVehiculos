using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaVehiculos_Api.Aplication.Interfaces;
using RentaVehiculos_Api.Domain.Models;

namespace RentaVehiculos_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentasController(IRentaServicio servicio) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> VerRentas() {
            var listadoRenta =  await servicio.Mostrar_Rentas();
            return Ok(listadoRenta);
        }

        [HttpPost("NuevaRenta")]
        [Authorize(Roles = "Cliente")]
        //aqui si pude ser un cliente
        public async Task<ActionResult> RentaNueva(Rentas_SP renta) {
            var miRenta = await servicio.NevaRenta(renta);
            return Ok(miRenta);

        }

        //actualizacion del estado renta en fecha_fin_real y monto_final a pagar
        [HttpPost("FinRenta")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> FinalizarRenta(Rentas_SP_Finalizar renta) {
            var finRenta = await servicio.Finalizacion_renta(renta);
            return Ok("Renta Finalizada");    
        }
    }
}
