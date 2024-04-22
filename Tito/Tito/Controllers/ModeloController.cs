using Core.Request;
using Core.Response;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Tito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        public readonly IModeloService _service;
        public ModeloController(IModeloService service)
        {
            _service = service;
        }
        [HttpGet("ListarModelo")]
        public async Task<IEnumerable<ModeloDtoOut>> GetModelo()
        {
            return await _service.GetModelo();
        }
        [HttpGet("Buscando/{id}")]
        public async Task<ActionResult<ModeloDtoOut?>> GetById(int id)
        {
            var modeloId = await _service.GetById(id);
            return modeloId;
        }
        [HttpPost("AgregandoModelo")]
        public async Task<IActionResult> PostModelo(ModeloDtoIn modeloDto)
        {
            var nuevoModelo = await _service.PostModelo(modeloDto);

             return CreatedAtAction(nameof(GetById), new { id = nuevoModelo.Id }, nuevoModelo);
        }
        [HttpPut("ModificandoModelo/{id}")]
        public async Task<IActionResult> PutModelo(int id, ModeloDtoIn modeloDto)
        {
            if (id != modeloDto.Id)
            {
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID ({modeloDto.Id} del cuerpo de la solicitud)" });
            }

            var existeModelo = await _service.GetById(id);
            if(existeModelo == null)
            {
                return NotFound();
            }
            if( existeModelo is not null)
            {
                await _service.PutModelo(id, modeloDto);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("EliminandoModelo/{id}")]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            var modelo =  _service.GetById(id);
            if(modelo == null)
            {
                NotFound();
            }
            if(modelo is not null)
            {
                await _service.DeleteModelo(id);
                return NoContent();
            }
            else
            {
                return NotFound(new { message = "El objeto NO fue Eliminado" });
            }
        }
    }
}
