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
    public class ServiceCategoriasArticulos : IServiceCategoriasArticulos
    {
        private readonly IRepositoryCategoriasArticulos _repository;

        public ServiceCategoriasArticulos(IRepositoryCategoriasArticulos repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<CategoriasArticulosDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();

            return list.Select(ca => new CategoriasArticulosDTO
            {
                Id = ca.Id,
                Nombre = ca.Nombre,
                Slug = ca.Slug,
                Activo = ca.Activo,

                // Evitar relación circular
                Articulos = new List<Llantera.Infraestructure.Models.Articulos>()
            }).ToList();
        }
    }
}
