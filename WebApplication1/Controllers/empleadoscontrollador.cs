using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using ParcialVisual.Data.repositorios;
using ParcialVisual.Modelo;

namespace ParcialVisual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosControllador : ControllerBase
    {
        public readonly iEmpleadosRepositorio _EmpleadosRepositorio;
        public EmpleadosControllador(iEmpleadosRepositorio EmpleadosRepositorio)
        {
            _EmpleadosRepositorio = EmpleadosRepositorio;
        }
        [HttpGet]

        public async Task<IActionResult> getempleados()
        {
            return Ok(await _EmpleadosRepositorio.getempleados());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getEmleadosById(int id)
        {
            return Ok(await _EmpleadosRepositorio.getempleadosById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Insertempleados([FromBody] empleados empleados)
        {
            if (empleados == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _EmpleadosRepositorio.insertempleados(empleados);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] empleados empleados)
        {
            if (empleados == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var update = await _EmpleadosRepositorio.updateempleados(empleados);
            return Ok(update);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteempleadosById(int id)
        {
            return Ok(await _EmpleadosRepositorio.deleteempleados(id));
        }

    }

    
}
