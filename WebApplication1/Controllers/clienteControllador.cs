using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using ParcialVisual.Modelo;

namespace ParcialVisual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clienteControllador : ControllerBase
    {
        public readonly iClienteRepositorio _clienteRepositorio;
        public clienteControllador(iClienteRepositorio clienteRepsitorio)
        {
            _clienteRepositorio = clienteRepsitorio;
        }
        [HttpGet]

        public async Task<IActionResult> getClientes()
        {
            return Ok(await _clienteRepositorio.getClientes());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getClientesById(int id)
        {
            return Ok(await _clienteRepositorio.getClientesById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertClientes([FromBody] Clientes clientes)
        {
            if (clientes == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _clienteRepositorio.insertClientes(clientes);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateClientes([FromBody] Clientes clientes)
        {
            if (clientes == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var update = await _clienteRepositorio.updateClientes(clientes);
            return Ok(update);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteClientesById(int id)
        {
            return Ok(await _clienteRepositorio.deleteClientes(id));
        }
    }
}
