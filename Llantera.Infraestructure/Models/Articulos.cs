using System;
using System.Collections.Generic;

namespace Llantera.Infraestructure.Models;

public partial class Articulos
{
    public int Id { get; set; }

    public int Idcategoria { get; set; }

    public string Titulo { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string Resumen { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public string? Imagen { get; set; }

    public string? MetaTitulo { get; set; }

    public string? MetaDescripcion { get; set; }

    public bool Activo { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual CategoriasArticulos IdcategoriaNavigation { get; set; } = null!;
}
