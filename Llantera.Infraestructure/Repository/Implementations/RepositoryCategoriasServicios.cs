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
    public class RepositoryCategoriasServicios : IRepositoryCategoriasServicios
    {
        private readonly LubricentroContext _context;

        public RepositoryCategoriasServicios(LubricentroContext context)
        {
            _context = context;
        }

        public async Task<CategoriasServicios> FindByIdAsync(int id)
        {
            return await _context.CategoriasServicios
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<CategoriasServicios>> ListAsync()
        {
            return await _context.CategoriasServicios
                .ToListAsync();
        }

        public async Task<CategoriasServicios> AddAsync(CategoriasServicios entity)
        {
            await _context.CategoriasServicios.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
