using Llantera.Application.DTOs;
using Llantera.Application.Services.Interfaces;
using Llantera.Application.Utils;
using Llantera.Infraestructure.Models;
using Llantera.Infraestructure.Repository.Interfaces;
using Mapster;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Application.Services.Implementations
{
    public class ServiceUsuarios : IServiceUsuarios
    {
        private readonly IRepositoryUsuarios _repository;
        private readonly IOptions<AppConfig> _options;

        public ServiceUsuarios(IRepositoryUsuarios repository, IOptions<AppConfig> options)
        {
            _repository = repository;
            _options = options;
        }

        public async Task<UsuariosDTO> FindByIdAsync(int id)
        {
            var u = await _repository.FindByIdAsync(id);

            if (u == null)
                return null;

            return new UsuariosDTO
            {
                Id = u.Id,
                Idrol = u.Idrol,
                Nombre = u.Nombre,
                Telefono = u.Telefono,
                Correo = u.Correo,
                Contrasenna = u.Contrasenna,
                Estado = u.Estado,


                IdrolNavigation = u.IdrolNavigation == null ? null : new RolDTO
                {
                    Id = u.IdrolNavigation.Id,
                    Descripcion = u.IdrolNavigation.Descripcion,
                    Usuarios = new List<UsuariosDTO>()
                },

            };
        }

        public async Task<string> AddAsync(UsuariosDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Contrasenna))
            {
                string secret = _options.Value.Crypto.Secret;
                dto.Contrasenna = Cryptography.Encrypt(dto.Contrasenna, secret);
            }
            else
            {
                dto.Contrasenna = null;
            }

            var entity = new Usuarios
            {
                Idrol = dto.Idrol,
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                Contrasenna = dto.Contrasenna,
                Estado = dto.Estado,
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<ICollection<UsuariosDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();

            return list.Select(u => new UsuariosDTO
            {
                Id = u.Id,
                Idrol = u.Idrol,
                Nombre = u.Nombre,
                Telefono = u.Telefono,
                Correo = u.Correo,
                Contrasenna = u.Contrasenna,
                Estado = u.Estado,

                IdrolNavigation = u.IdrolNavigation == null ? null : new RolDTO
                {
                    Id = u.IdrolNavigation.Id,
                    Descripcion = u.IdrolNavigation.Descripcion,
                    Usuarios = new List<UsuariosDTO>()
                },

            }).ToList();
        }


        public async Task<UsuariosDTO> LoginAsync(string id, string contrasenna)
        {
            string secret = _options.Value.Crypto.Secret;
            string passwordEncrypted = Cryptography.Encrypt(contrasenna, secret);

            var u = await _repository.LoginAsync(id, passwordEncrypted);

            if (u == null)
                return null;

            return new UsuariosDTO
            {
                Id = u.Id,
                Idrol = u.Idrol,
                Nombre = u.Nombre,
                Telefono = u.Telefono,
                Correo = u.Correo,
                Contrasenna = u.Contrasenna,
                Estado = u.Estado,

                IdrolNavigation = u.IdrolNavigation == null ? null : new RolDTO
                {
                    Id = u.IdrolNavigation.Id,
                    Descripcion = u.IdrolNavigation.Descripcion,
                    Usuarios = new List<UsuariosDTO>()
                },

            };
        }

        public async Task UpdateAsync(int id, UsuariosDTO dto)
        {
            var entity = await _repository.FindByIdAsync(id);
            if (entity is null)
                throw new KeyNotFoundException($"Usuario {id} no encontrado.");

            var config = new TypeAdapterConfig();

            config.NewConfig<UsuariosDTO, Usuarios>()
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.Contrasenna)
                .Ignore(dest => dest.IdrolNavigation);

            dto.Adapt(entity, config);

            // Mantener rol original si no viene uno válido
            if (dto.Idrol == 0)
                entity.Idrol = entity.Idrol;

            await _repository.UpdateAsync();
        }

        public async Task<bool> ExisteCorreoAsync(string correo, int id)
        {
            var usuarios = await _repository.ListAsync();
            return usuarios.Any(u => u.Correo == correo && u.Id != id);
        }
    }
}
