using Llantera.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Application.Services.Interfaces
{
    public interface IServiceUsuarios
    {
        Task<UsuariosDTO> FindByIdAsync(int id);
        Task<ICollection<UsuariosDTO>> ListAsync();
        Task<UsuariosDTO> LoginAsync(string id, string contrasenna);
        Task<string> AddAsync(UsuariosDTO dto);
        Task UpdateAsync(int id, UsuariosDTO dto);
        Task<bool> ExisteCorreoAsync(string correo, int id);
    }
}
