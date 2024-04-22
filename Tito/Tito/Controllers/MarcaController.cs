using Core.Request;
using Core.Response;
using Data.Models;
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
            var marca = await _service.GetById(id);
            return (marca);
        }

        [HttpPost("AgregandoMarca")]
        public async Task<IActionResult> PostMarca(MarcaDtoIn marcaDtoIn)
        {
            var newMarca = await _service.PostMarca(marcaDtoIn);
            return CreatedAtAction(nameof(GetUnicoMarca), new { id = newMarca.Id }, newMarca);
        }


        [HttpPut("Modificando/{id}")]
        public async Task<IActionResult> PutMarca(int id, MarcaDtoIn marcaDtoIn)
        {
            if (id != marcaDtoIn.Id)
            {
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID ({marcaDtoIn.Id} del cuerpo de la solicitud)" });
            }
            var marcaUp = await GetUnicoMarca(id);
            if (marcaUp is not null)
            {
                await _service.PutMarca(id, marcaDtoIn);
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
            var marcaD = await _service.GetById(id);
            if (marcaD is null)
            {
                return NotFound();
            }
            if (marcaD.Id != id)
            {
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID ({marcaD.Id} del cuerpo de la solicitud)" });
            }
            var marca = _service.GetById(id);
            if (marca is not null)
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

