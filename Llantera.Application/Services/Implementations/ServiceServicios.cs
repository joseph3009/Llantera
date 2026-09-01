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
    public class ServiceServicios : IServiceServicios
    {
        private readonly IRepositoryServicios _repository;

        public ServiceServicios(IRepositoryServicios repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<ServiciosDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();

            return list.Select(s => new ServiciosDTO
            {
                Id = s.Id,
                Idcategoria = s.Idcategoria,
                Titulo = s.Titulo,
                Slug = s.Slug,
                DescripcionCorta = s.DescripcionCorta,
                DescripcionLarga = s.DescripcionLarga,
                Imagen = s.Imagen,
                Activo = s.Activo,
                Orden = s.Orden,
                FechaRegistro = s.FechaRegistro
            }).ToList();
        }
    }
}
