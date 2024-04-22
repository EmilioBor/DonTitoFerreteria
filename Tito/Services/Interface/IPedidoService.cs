using Core.Request;
using Data.Models;

namespace Services.Interface
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDtoOut>> GetPedido();
        Task<PedidoDtoOut?> GetById(int id);
        Task<Pedido> PostPedido(PedidoDtoIn PedidoDto);
        Task<Pedido?> GetId(int id);
        Task PutPedido(int id, PedidoDtoIn pedido);
        Task DeletePedido(int id);
    }
}