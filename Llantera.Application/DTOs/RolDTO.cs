using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llantera.Application.DTOs
{
    public record class RolDTO
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = null!;

        public virtual List<UsuariosDTO> Usuarios { get; set; } = new List<UsuariosDTO>();
    }
}
