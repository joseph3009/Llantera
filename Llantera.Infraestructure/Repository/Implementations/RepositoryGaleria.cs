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
    public class RepositoryGaleria : IRepositoryGaleria
    {
        private readonly LubricentroContext _context;

        public RepositoryGaleria(LubricentroContext context)
        {
            _context = context;
        }

        public async Task<Galeria> FindByIdAsync(int id)
        {
            return await _context.Galeria
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Galeria>> ListAsync()
        {
            return await _context.Galeria
                .ToListAsync();
        }

        public async Task<Galeria> AddAsync(Galeria entity)
        {
            await _context.Galeria.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
