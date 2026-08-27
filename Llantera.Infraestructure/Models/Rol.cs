using System;
using System.Collections.Generic;

namespace Llantera.Infraestructure.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
