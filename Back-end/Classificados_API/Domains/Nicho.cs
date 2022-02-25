using System;
using System.Collections.Generic;

#nullable disable

namespace Classificados_API.Domains
{
    public partial class Nicho
    {
        public Nicho()
        {
            Categoria = new HashSet<Categoria>();
        }

        public byte IdNicho { get; set; }
        public string Nicho1 { get; set; }

        public virtual ICollection<Categoria> Categoria { get; set; }
    }
}
