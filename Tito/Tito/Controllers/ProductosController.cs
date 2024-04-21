using Core.Request;
using Core.Response;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Tito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        public readonly IProductoService _service;
        public ProductosController(IProductoService service)
        {
            _service = service;
        }
        [HttpGet("listaProducto")]
        public async Task<IEnumerable<ProductoDtoOut>> GetProducto()
        {
            return await _service.GetProducto();
        }

        [HttpGet("Buscando/{id}")]
        public async Task<ActionResult<ProductoDtoOut?>> GetUnicoProducto(int id)
        {
            var productoId = await _service.GetById(id);
            return (productoId);
        }

        [HttpPost("AgregandoProducto")]
        public async Task<IActionResult> PostProducto(ProductoDtoIn productoDtoIn)
        {
             var newProducto= await _service.PostProducto(productoDtoIn);
            return CreatedAtAction(nameof(GetUnicoProducto), new { id = newProducto.Id}, newProducto);
        }
        [HttpPut("Modificando/{id}")]
        public async Task<IActionResult> PutProducto(int id, ProductoDtoIn productoDto)
        {
            if (id != productoDto.Id)
            {
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID ({productoDto.Id} del cuerpo de la solicitud)" });
            }
                var productoUpdate = _service.GetById(id);
                if (productoUpdate is not null)
                {
                    await _service.PutProducto(id, productoDto);
                    return NoContent();
                    //new { message = "El objeto fue modificado" }
                }
                else
            {
                return NotFound(new { message = "El objeto NO fue modificado" });
            }
            
        }
        [HttpDelete("EliminarProducto/{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _service.GetById(id);
            if (producto is null)
            {
                return NotFound();
            }
            if ( producto.Id != id)
            {
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID ({producto.Id} del cuerpo de la solicitud)" });
            }
            var productoUpdate = _service.GetById(id);
            if (productoUpdate is not null)
            {
                await _service.DeleteProducto(id);
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
