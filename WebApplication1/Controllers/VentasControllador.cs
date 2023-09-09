using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using ParcialVisual.Data.repositorios;
using ParcialVisual.Modelo;

namespace ParcialVisual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasControllador : ControllerBase
    {
        public readonly iVentasRepositorio _VentasRepositorio;
        public VentasControllador(iVentasRepositorio VentasRepositorio)
        {
            _VentasRepositorio = VentasRepositorio;
        }
        [HttpPost]
        public async Task<IActionResult> InsertVentas([FromBody] Ventas Ventas)
        {
            if (Ventas == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _VentasRepositorio.insertventas(Ventas);
            return Ok(created);
        }
    }
}
