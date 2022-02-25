using System;
using System.Collections.Generic;

#nullable disable

namespace Classificados_API.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Classificados = new HashSet<Classificado>();
            ImagemBancos = new HashSet<ImagemBanco>();
            Oferta = new HashSet<Oferta>();
        }

        public int IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Ddd { get; set; }
        public string Telefone { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Classificado> Classificados { get; set; }
        public virtual ICollection<ImagemBanco> ImagemBancos { get; set; }
        public virtual ICollection<Oferta> Oferta { get; set; }
    }
}
