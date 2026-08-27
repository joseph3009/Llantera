using Llantera.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Application.DTOs
{
    public record class ServiciosDTO
    {
        public int Id { get; set; }

        public int Idcategoria { get; set; }

        public string Titulo { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public string DescripcionCorta { get; set; } = null!;

        public string DescripcionLarga { get; set; } = null!;

        public byte[]? Imagen { get; set; }

        public bool Activo { get; set; }

        public int Orden { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual CategoriasServiciosDTO IdcategoriaNavigation { get; set; } = null!;
    }
}
