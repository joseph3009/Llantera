using Llantera.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryUsuarios
    {
        Task<Usuarios> FindByIdAsync(int id);
        Task<ICollection<Usuarios>> ListAsync();
        Task<Usuarios> LoginAsync(string id, string contrasenna);
        Task<string> AddAsync(Usuarios entity);
        Task UpdateAsync();
    }
}
