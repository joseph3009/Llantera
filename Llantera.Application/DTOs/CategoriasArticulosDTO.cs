using Llantera.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Application.DTOs
{
    public record class CategoriasArticulosDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public bool Activo { get; set; }

        public virtual List<Articulos> Articulos { get; set; } = new List<Articulos>();
    }
}
