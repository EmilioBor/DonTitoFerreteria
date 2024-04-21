using Core.Request;
using Core.Response;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Tito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        public readonly IMarcaService _service;
        public MarcasController(IMarcaService service)
        {
            _service = service;
        }
        [HttpGet("listaMarca")]
        public async Task<IEnumerable<MarcaDtoOut>> GetMarca()
        {
            return await _service.GetMarca();
        }

        [HttpGet("Buscando/{id}")]
        public async Task<ActionResult<MarcaDtoOut?>> GetUnicoMarca(int id)
        {
            var productoId = await _service.GetById(id);
            return (productoId);
        }

        [HttpPost("AgregandoMarca")]
        public async Task<IActionResult> PostMarca(MarcaDtoIn productoDtoIn)
        {
            var newMarca = await _service.PostMarca(productoDtoIn);
            return CreatedAtAction(nameof(GetUnicoMarca), new { id = newMarca.Id }, newMarca);
        }
        [HttpPut("Modificando/{id}")]
        public async Task<IActionResult> PutMarca(int id, MarcaDtoIn productoDto)
        {
            if (id != productoDto.Id)
            {
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID ({productoDto.Id} del cuerpo de la solicitud)" });
            }
            var productoUpdate = _service.GetById(id);
            if (productoUpdate is not null)
            {
                await _service.PutMarca(id, productoDto);
                return NoContent();
                //new { message = "El objeto fue modificado" }
            }
            else
            {
                return NotFound(new { message = "El objeto NO fue modificado" });
            }

        }
        [HttpDelete("EliminarMarca/{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var marca = await _service.GetById(id);
            if (marca is null)
            {
                return NotFound();
            }
            if (marca.Id != id)
            {
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID ({marca.Id} del cuerpo de la solicitud)" });
            }
            var productoUpdate = _service.GetById(id);
            if (productoUpdate is not null)
            {
                await _service.DeleteMarca(id);
                return NoContent();
                //new { message = "El objeto fue modificado" }
            }
            else
            {
                return NotFound(new { message = "El objeto NO fue Eliminado" });
            }
        }
    }
}

