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
    public class RepositoryRol : IRepositoryRol
    {
        private readonly LubricentroContext _context;

        public RepositoryRol(LubricentroContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Rol>> ListAsync()
        {
            var collection = await _context.Set<Rol>().ToListAsync();
            return collection;
        }
    }
}
