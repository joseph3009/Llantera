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
    public class RepositoryServicios : IRepositoryServicios
    {
        private readonly LubricentroContext _context;

        public RepositoryServicios(LubricentroContext context)
        {
            _context = context;
        }

        public async Task<Servicios> FindByIdAsync(int id)
        {
            return await _context.Servicios
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Servicios>> ListAsync()
        {
            return await _context.Servicios
                .ToListAsync();
        }

        public async Task<Servicios> AddAsync(Servicios entity)
        {
            await _context.Servicios.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
