using System;
using System.Collections.Generic;

namespace Llantera.Infraestructure.Models;

public partial class Galeria
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public byte[] Imagen { get; set; } = null!;

    public int Orden { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaRegistro { get; set; }
}
