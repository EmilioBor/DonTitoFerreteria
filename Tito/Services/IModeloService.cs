using Core.Response;

namespace Services
{
    public interface IModeloService
    {
        Task<IEnumerable<ModeloDtoOut>> GetModelo();
        Task<ModeloDtoOut?> GetById(int id);
    }
}