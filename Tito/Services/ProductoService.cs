using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ProductoService : IProductoService
    {
        public readonly TitoContext _context;
        public ProductoService(TitoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductoDtoOut>> GetProducto()
        {
            return await _context.Producto
                .Select(p => new ProductoDtoOut
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Cantidad = p.Cantidad
            }).ToListAsync();
        }
        public async Task<ProductoDtoOut?> GetById(int id)
        {
            return await _context.Producto
                .Where(p => p.Id == id)
                .Select(n => new ProductoDtoOut
                    {
                        Id = n.Id,
                        Nombre = n.Nombre,
                        Cantidad = n.Cantidad
                    }).SingleOrDefaultAsync();
        }


        public async Task<Producto> PostProducto(ProductoDtoIn productoDto)
        {
            var producto = new Producto();

            
            producto.Nombre = productoDto.Nombre;
            producto.Cantidad = productoDto.Cantidad;

            _context.Add(producto);
            await _context.SaveChangesAsync();
            return (producto);
        }
        public async Task<Producto?> GetId(int id)
        {
            return await _context.Producto.FindAsync(id);
        }
        public async Task PutProducto(int id, ProductoDtoIn producto)
        {
            var productoUp = await GetId(id);
            if (productoUp != null)
            {
                //productoUp.Id = producto.Id;
                productoUp.Nombre = producto.Nombre;
                productoUp.Cantidad = producto.Cantidad;

                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteProducto(int id)
        {
            var productoDe = await GetId(id);
            if (productoDe != null)
            {
                _context.Producto.Remove(productoDe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
