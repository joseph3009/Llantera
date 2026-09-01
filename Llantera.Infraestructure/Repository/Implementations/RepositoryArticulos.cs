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
    public class RepositoryArticulos : IRepositoryArticulos
    {
        private readonly LubricentroContext _context;

        public RepositoryArticulos(LubricentroContext context)
        {
            _context = context;
        }

        public async Task<Articulos> FindByIdAsync(int id)
        {
            return await _context.Articulos
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Articulos>> ListAsync()
        {
            return await _context.Articulos
                .ToListAsync();
        }

        public async Task<Articulos> AddAsync(Articulos entity)
        {
            await _context.Articulos.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
