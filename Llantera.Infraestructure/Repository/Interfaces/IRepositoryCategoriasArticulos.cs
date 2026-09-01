using Llantera.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryCategoriasArticulos
    {
        Task<ICollection<CategoriasArticulos>> ListAsync();
        Task<CategoriasArticulos> FindByIdAsync(int id);

        Task<CategoriasArticulos> AddAsync(CategoriasArticulos entity);
        Task UpdateAsync();
    }
}
