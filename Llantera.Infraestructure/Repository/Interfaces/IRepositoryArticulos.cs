using Llantera.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryArticulos
    {
        Task<ICollection<Articulos>> ListAsync();
        Task<Articulos> FindByIdAsync(int id);

        Task<Articulos> AddAsync(Articulos entity);
        Task UpdateAsync();
    }
}
