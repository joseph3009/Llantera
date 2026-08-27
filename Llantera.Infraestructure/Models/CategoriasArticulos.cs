using System;
using System.Collections.Generic;

namespace Llantera.Infraestructure.Models;

public partial class CategoriasArticulos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Articulos> Articulos { get; set; } = new List<Articulos>();
}
