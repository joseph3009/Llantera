using Llantera.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryCategoriasServicios
    {
        Task<ICollection<CategoriasServicios>> ListAsync();
        Task<CategoriasServicios> FindByIdAsync(int id);

        Task<CategoriasServicios> AddAsync(CategoriasServicios entity);
        Task UpdateAsync();
    }
}
