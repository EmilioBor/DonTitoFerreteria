using Core.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Tito.Controllers
{
    public class ModeloController
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
            var modelo = await _service.GetById(id);
            
                return modelo;
            
            
        }
    }
}
