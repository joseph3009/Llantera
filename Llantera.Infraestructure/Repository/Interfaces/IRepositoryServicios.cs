using Llantera.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryServicios
    {
        Task<ICollection<Servicios>> ListAsync();
        Task<Servicios> FindByIdAsync(int id);

        Task<Servicios> AddAsync(Servicios entity);
        Task UpdateAsync();
    }
}
