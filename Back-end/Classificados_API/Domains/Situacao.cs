using System;
using System.Collections.Generic;

#nullable disable

namespace Classificados_API.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Classificados = new HashSet<Classificado>();
            Oferta = new HashSet<Oferta>();
        }

        public byte IdSituacao { get; set; }
        public string Situacao1 { get; set; }

        public virtual ICollection<Classificado> Classificados { get; set; }
        public virtual ICollection<Oferta> Oferta { get; set; }
    }
}
