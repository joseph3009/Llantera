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
    public class ServiceGaleria : IServiceGaleria
    {
        private readonly IRepositoryGaleria _repository;

        public ServiceGaleria(IRepositoryGaleria repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<GaleriaDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();

            return list.Select(g => new GaleriaDTO
            {
                Id = g.Id,
                Titulo = g.Titulo,
                Descripcion = g.Descripcion,
                Imagen = g.Imagen,
                Orden = g.Orden,
                Activo = g.Activo,
                FechaRegistro = g.FechaRegistro
            }).ToList();
        }
    }
}
