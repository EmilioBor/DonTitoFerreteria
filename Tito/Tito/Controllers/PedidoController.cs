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
    public class PedidoController : ControllerBase
    {
        public readonly IPedidoService _service;
        public PedidoController(IPedidoService service)
        {
            _service = service;
        }
        [HttpGet("ListarModelo")]
        public async Task<IEnumerable<PedidoDtoOut>> GetPedido()
        {
            return await _service.GetPedido();
        }
        [HttpGet("Buscando/{id}")]
        public async Task<ActionResult<PedidoDtoOut?>> GetById(int id)
        {
            var pedidoId = await _service.GetById(id);
            return pedidoId;
        }
        [HttpPost("AgregandoPedido")]
        public async Task<IActionResult> PostPedido(PedidoDtoIn pedidoDto)
        {
            var nuevoPedido = await _service.PostPedido(pedidoDto);

            return CreatedAtAction(nameof(GetById), new { id = nuevoPedido.Id }, nuevoPedido);
        }
        [HttpPut("ModificandoPedido/{id}")]
        public async Task<IActionResult> PutPedido(int id, PedidoDtoIn pedidoDto)
        {
            if (id != pedidoDto.Id)
            {
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID ({pedidoDto.Id} del cuerpo de la solicitud)" });
            }

            var existePedido = await _service.GetById(id);
            if (existePedido == null)
            {
                return NotFound();
            }
            if (existePedido is not null)
            {
                await _service.PutPedido(id, pedidoDto);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("EliminandoPedido/{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = _service.GetById(id);
            if (pedido == null)
            {
                NotFound();
            }
            if (pedido is not null)
            {
                await _service.DeletePedido(id);
                return NoContent();
            }
            else
            {
                return NotFound(new { message = "El objeto NO fue Eliminado" });
            }
        }
    }
}
