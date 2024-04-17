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
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                NombreMarca = p.IdMarcaNavigation.Nombre,
                NombreModelo = p.IdModeloNavigation.Nombre
            }).ToListAsync();
        }
        public async Task<ProductoDtoOut?> GetById(int id)
        {
            return await _context.Producto
                .Where(p => p.Id == id)
                .Select(p => new ProductoDtoOut
                    {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    NombreMarca = p.IdMarcaNavigation.Nombre,
                    NombreModelo = p.IdModeloNavigation.Nombre
                }).SingleOrDefaultAsync();
        }


        public async Task<Producto> PostProducto(ProductoDtoIn productoDto)
        {
            var producto = new Producto();

            
            producto.Nombre = productoDto.Nombre;
            producto.Descripcion = productoDto.Descripcion;
            producto.Precio = productoDto.Precio;
            producto.IdMarca = productoDto.IdMarca;
            producto.IdModelo = productoDto.IdModelo;

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
                productoUp.Descripcion = producto.Descripcion;
                productoUp.Precio = producto.Precio;
                productoUp.IdModelo = producto.IdModelo;
                productoUp.IdMarca = producto.IdMarca;

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
