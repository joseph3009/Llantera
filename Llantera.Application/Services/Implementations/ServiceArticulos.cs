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
    public class ServiceArticulos : IServiceArticulos
    {
        private readonly IRepositoryArticulos _repository;

        public ServiceArticulos(IRepositoryArticulos repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<ArticulosDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();

            return list.Select(a => new ArticulosDTO
            {
                Id = a.Id,
                Idcategoria = a.Idcategoria,
                Titulo = a.Titulo,
                Slug = a.Slug,
                Resumen = a.Resumen,
                Contenido = a.Contenido,
                Imagen = a.Imagen,
                MetaTitulo = a.MetaTitulo,
                MetaDescripcion = a.MetaDescripcion,
                Activo = a.Activo
            }).ToList();
        }
    }
}
