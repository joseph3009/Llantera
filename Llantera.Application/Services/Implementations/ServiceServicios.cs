using Llantera.Application.DTOs;
using Llantera.Application.Services.Interfaces;
using Llantera.Infraestructure.Models;
using Llantera.Infraestructure.Repository.Interfaces;
using Mapster;
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

            return list.Adapt<ICollection<ServiciosDTO>>();
        }

        public async Task<ServiciosDTO> FindByIdAsync(int id)
        {
            var entity = await _repository.FindByIdAsync(id);

            return entity == null
                ? null
                : entity.Adapt<ServiciosDTO>();
        }

        public async Task<ServiciosDTO> AddAsync(ServiciosDTO dto)
        {
            var entity = new Servicios
            {
                Idcategoria = dto.Idcategoria,
                Titulo = dto.Titulo,
                Slug = dto.Slug,
                DescripcionCorta = dto.DescripcionCorta,
                DescripcionLarga = dto.DescripcionLarga,
                Imagen = dto.Imagen,
                Activo = dto.Activo,
                Orden = dto.Orden,
                FechaRegistro = DateTime.Now
            };

            var result = await _repository.AddAsync(entity);

            return result.Adapt<ServiciosDTO>();
        }

        public async Task UpdateAsync(int id, ServiciosDTO dto)
        {
            var entity = await _repository.FindByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException(
                    $"Servicio con ID {id} no encontrado."
                );

            entity.Idcategoria = dto.Idcategoria;
            entity.Titulo = dto.Titulo;
            entity.Slug = dto.Slug;
            entity.DescripcionCorta = dto.DescripcionCorta;
            entity.DescripcionLarga = dto.DescripcionLarga;
            entity.Imagen = dto.Imagen;
            entity.Activo = dto.Activo;
            entity.Orden = dto.Orden;

            await _repository.UpdateAsync();
        }
    }
}
