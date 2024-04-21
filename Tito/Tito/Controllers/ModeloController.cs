using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

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

    }
}
