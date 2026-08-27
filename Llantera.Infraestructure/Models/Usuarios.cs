using System;
using System.Collections.Generic;

namespace Llantera.Infraestructure.Models;

public partial class Usuarios
{
    public int Id { get; set; }

    public int Idrol { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Contrasenna { get; set; }

    public bool Estado { get; set; }

    public virtual Rol IdrolNavigation { get; set; } = null!;
}
