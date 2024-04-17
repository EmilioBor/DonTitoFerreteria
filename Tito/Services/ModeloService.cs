﻿using Core.Response;
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
            return await _context.Modelo.FirstAsync(id);
        }
    }
}