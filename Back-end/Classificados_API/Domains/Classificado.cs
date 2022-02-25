using System;
using System.Collections.Generic;

#nullable disable

namespace Classificados_API.Domains
{
    public partial class Classificado
    {
        public Classificado()
        {
            ImagemBancos = new HashSet<ImagemBanco>();
            Oferta = new HashSet<Oferta>();
        }

        public int IdClassificado { get; set; }
        public int? IdUsuario { get; set; }
        public byte? IdSituacao { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCricao { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public short? Acessos { get; set; }

        public virtual Situacao IdSituacaoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<ImagemBanco> ImagemBancos { get; set; }
        public virtual ICollection<Oferta> Oferta { get; set; }
    }
}
