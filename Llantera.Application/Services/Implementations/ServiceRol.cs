using Llantera.Application.DTOs;
using Llantera.Application.Services.Interfaces;
using Llantera.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Application.Services.Implementations
{
    public class ServiceRol : IServiceRol
    {
        private readonly IRepositoryRol _repository;

        public ServiceRol(IRepositoryRol repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<RolDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();

            return list.Select(r => new RolDTO
            {
                Id = r.Id,
                Descripcion = r.Descripcion,

            }).ToList();
        }
    }
}
