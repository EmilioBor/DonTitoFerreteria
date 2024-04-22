using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interface;

namespace Services.Service
{
    public class MarcaService : IMarcaService
    {
        public readonly TitoContext _context;
        public MarcaService(TitoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MarcaDtoOut>> GetMarca()
        {
            return await _context.Marca
                .Select(p => new MarcaDtoOut
                {
                    Id = p.Id,
                    Nombre = p.Nombre,

                }).ToListAsync();
        }
        public async Task<MarcaDtoOut?> GetById(int id)
        {
            return await _context.Marca
                .Where(p => p.Id == id)
                .Select(p => new MarcaDtoOut
                {
                    Id = p.Id,
                    Nombre = p.Nombre,

                }).SingleOrDefaultAsync();
        }


        public async Task<Marca> PostMarca(MarcaDtoIn MarcaDto)
        {
            var marca = new Marca();


            marca.Nombre = MarcaDto.Nombre;


            _context.Add(marca);
            await _context.SaveChangesAsync();
            return marca;
        }
        public async Task<Marca?> GetId(int id)
        {
            return await _context.Marca.FindAsync(id);
        }
        public async Task PutMarca(int id, MarcaDtoIn marca)
        {
            var MarcaUp = await GetId(id);
            if (MarcaUp != null)
            {
                //MarcaUp.Id = marca.Id;
                MarcaUp.Nombre = marca.Nombre;


                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteMarca(int id)
        {
            var MarcaDe =  await GetId(id);
            if (MarcaDe is not null)
            {
                _context.Marca.Remove(MarcaDe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
