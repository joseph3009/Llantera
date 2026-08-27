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
    public class RepositoryUsuarios : IRepositoryUsuarios
    {
        private readonly LubricentroContext _context;

        public RepositoryUsuarios(LubricentroContext context)
        {
            _context = context;
        }

        public async Task<Usuarios> FindByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(p => p.IdrolNavigation)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<string> AddAsync(Usuarios entity)
        {
            await _context.Set<Usuarios>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Correo;
        }

        public async Task<ICollection<Usuarios>> ListAsync()
        {
            var collection = await _context.Set<Usuarios>().Include(p => p.IdrolNavigation).ToListAsync();
            return collection;
        }

        public async Task<Usuarios> LoginAsync(string id, string contrasenna)
        {
            var @object = await _context.Set<Usuarios>().Include(b => b.IdrolNavigation)
                .Where(p => p.Correo == id && p.Contrasenna == contrasenna)
                .FirstOrDefaultAsync();

            return @object!;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
