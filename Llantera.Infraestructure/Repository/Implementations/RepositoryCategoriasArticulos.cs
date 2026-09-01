using Llantera.Infraestructure.Data;
using Llantera.Infraestructure.Models;
using Llantera.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Infraestructure.Repository.Implementations
{
    public class RepositoryCategoriasArticulos : IRepositoryCategoriasArticulos
    {
        private readonly LubricentroContext _context;

        public RepositoryCategoriasArticulos(LubricentroContext context)
        {
            _context = context;
        }

        public async Task<CategoriasArticulos> FindByIdAsync(int id)
        {
            return await _context.CategoriasArticulos
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<CategoriasArticulos>> ListAsync()
        {
            return await _context.CategoriasArticulos
                .ToListAsync();
        }

        public async Task<CategoriasArticulos> AddAsync(CategoriasArticulos entity)
        {
            await _context.CategoriasArticulos.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
