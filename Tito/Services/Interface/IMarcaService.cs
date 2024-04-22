using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaDtoOut>> GetMarca();
        Task<MarcaDtoOut?> GetById(int id);
        Task<Marca> PostMarca(MarcaDtoIn MarcaDto);
        Task PutMarca(int id, MarcaDtoIn marca);
        Task<Marca?> GetId(int id);
        Task DeleteMarca(int id);
    }
}