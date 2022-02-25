using System;
using System.Collections.Generic;

#nullable disable

namespace Classificados_API.Domains
{
    public partial class Categoria
    {
        public short IdCategoria { get; set; }
        public byte? IdNicho { get; set; }
        public string Categoria1 { get; set; }

        public virtual Nicho IdNichoNavigation { get; set; }
    }
}
