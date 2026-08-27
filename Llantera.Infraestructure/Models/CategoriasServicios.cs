using System;
using System.Collections.Generic;

namespace Llantera.Infraestructure.Models;

public partial class CategoriasServicios
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Servicios> Servicios { get; set; } = new List<Servicios>();
}
