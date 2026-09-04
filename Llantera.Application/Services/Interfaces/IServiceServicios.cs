using Llantera.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Application.Services.Interfaces
{
    public interface IServiceServicios
    {
        Task<ICollection<ServiciosDTO>> ListAsync();
        Task<ServiciosDTO> FindByIdAsync(int id);
        Task<ServiciosDTO> AddAsync(ServiciosDTO dto);
        Task UpdateAsync(int id, ServiciosDTO dto);
    }
}
