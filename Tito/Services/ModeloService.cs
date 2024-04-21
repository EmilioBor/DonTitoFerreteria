using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ModeloService : IModeloService
    {
        public readonly TitoContext _context;
        public ModeloService(TitoContext context) {  _context = context; }

        public async Task<IEnumerable<ModeloDtoOut>> GetModelo()
        {
            return await _context.Modelo.Select(m => new ModeloDtoOut
            {
                Id = m.Id,
                Nombre = m.Nombre
            }).ToListAsync();
        }
        public async Task<ModeloDtoOut?> GetById(int id)
        {
            return await _context.Modelo
                .Where(m => m.Id == id)
                .Select(m => new ModeloDtoOut
            {
                Id = m.Id,
                Nombre = m.Nombre
            }).SingleOrDefaultAsync();
        }
        public async Task<Modelo> PostModelo(ModeloDtoIn modeloDto)
        {
            var modelo = new Modelo();

            modelo.Nombre = modeloDto.Nombre;

            _context.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
        public async Task PutModelo(int id, ModeloDtoIn modeloDto)
        {
            var modeloUp = await GetById(id);
            if(modeloUp is not null)
            {
                modeloUp.Nombre = modeloDto.Nombre;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteModelo(int id)
        {
            var modelo = await GetById(id);
            if(modelo is not null)
            {
                _context.Remove(modelo);
            }
        }
    }
}
