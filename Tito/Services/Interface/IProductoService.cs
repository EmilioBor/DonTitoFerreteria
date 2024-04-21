using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interface
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDtoOut>> GetProducto();
        Task<ProductoDtoOut?> GetById(int id);
        Task<Producto> PostProducto(ProductoDtoIn productoDto);
        Task PutProducto(int id, ProductoDtoIn producto);
        Task DeleteProducto(int id);
    }
}