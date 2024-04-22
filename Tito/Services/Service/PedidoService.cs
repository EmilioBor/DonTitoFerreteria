using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interface;

namespace Services.Service
{
    public class PedidoService : IPedidoService
    {
        public readonly TitoContext _context;
        public PedidoService(TitoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PedidoDtoOut>> GetPedido()
        {
            return await _context.Pedido
                .Select(p => new PedidoDtoOut
                {
                    Id = p.Id,
                    Cantidad = p.Cantidad,
                    Precio = p.Precio

                }).ToListAsync();
        }
        public async Task<PedidoDtoOut?> GetById(int id)
        {
            return await _context.Pedido
                .Where(p => p.Id == id)
                .Select(p => new PedidoDtoOut
                {
                    Id = p.Id,
                    Cantidad = p.Cantidad,
                    Precio = p.Precio

                }).SingleOrDefaultAsync();
        }


        public async Task<Pedido> PostPedido(PedidoDtoIn PedidoDto)
        {
            var pedido = new Pedido();


            pedido.Cantidad = PedidoDto.Cantidad;
            pedido.Precio = PedidoDto.Precio;


            _context.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }
        public async Task<Pedido?> GetId(int id)
        {
            return await _context.Pedido.FindAsync(id);
        }
        public async Task PutPedido(int id, PedidoDtoIn pedido)
        {
            var PedidoUp = await GetId(id);
            if (PedidoUp != null)
            {
                //PedidoUp.Id = pedido.Id;
                PedidoUp.Cantidad = pedido.Cantidad;
                PedidoUp.Precio = pedido.Precio;

                await _context.SaveChangesAsync();
            }
        }
        public async Task DeletePedido(int id)
        {
            var PedidoDe = await GetId(id);
            if (PedidoDe is not null)
            {
                _context.Pedido.Remove(PedidoDe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
