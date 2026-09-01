using Llantera.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryGaleria
    {
        Task<ICollection<Galeria>> ListAsync();
        Task<Galeria> FindByIdAsync(int id);

        Task<Galeria> AddAsync(Galeria entity);
        Task UpdateAsync();
    }
}
