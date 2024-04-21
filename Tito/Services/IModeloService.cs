using Core.Request;
using Core.Response;
using Data.Models;

namespace Services
{
    public interface IModeloService
    {
        Task<IEnumerable<ModeloDtoOut>> GetModelo();
        Task<ModeloDtoOut?> GetById(int id);
        Task<Modelo> PostModelo(ModeloDtoIn modeloDto);
        Task PutModelo(int id, ModeloDtoIn modeloDto);
        Task DeleteModelo(int id);
    }
}