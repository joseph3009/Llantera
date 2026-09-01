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
    public class ServiceCategoriasServicios : IServiceCategoriasServicios
    {
        private readonly IRepositoryCategoriasServicios _repository;

        public ServiceCategoriasServicios(IRepositoryCategoriasServicios repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<CategoriasServiciosDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();

            return list.Select(cs => new CategoriasServiciosDTO
            {
                Id = cs.Id,
                Nombre = cs.Nombre,
                Descripcion = cs.Descripcion,
                Activo = cs.Activo,

            }).ToList();
        }
    }
}
