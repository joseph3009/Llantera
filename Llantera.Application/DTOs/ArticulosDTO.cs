using Llantera.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Application.DTOs
{
    public record class ArticulosDTO
    {
        public int Id { get; set; }

        public int Idcategoria { get; set; }

        public string Titulo { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public string Resumen { get; set; } = null!;

        public string Contenido { get; set; } = null!;

        public byte[]? Imagen { get; set; }

        public string? MetaTitulo { get; set; }

        public string? MetaDescripcion { get; set; }

        public bool Activo { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual CategoriasArticulosDTO IdcategoriaNavigation { get; set; } = null!;
    }
}
