using Llantera.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Application.Services.Interfaces
{
    public interface IServiceArticulos
    {
        Task<ICollection<ArticulosDTO>> ListAsync();
    }
}
