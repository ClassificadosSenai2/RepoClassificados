using System;
using System.Collections.Generic;

#nullable disable

namespace Classificados_API.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoUsuario { get; set; }
        public string TipoUsuario1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
