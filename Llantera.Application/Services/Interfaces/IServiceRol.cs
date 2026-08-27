using Llantera.Application.DTOs;
using Llantera.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Application.Services.Interfaces
{
    public interface IServiceRol
    {
        Task<ICollection<RolDTO>> ListAsync();
    }
}
