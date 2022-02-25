using System;
using System.Collections.Generic;

#nullable disable

namespace Classificados_API.Domains
{
    public partial class Oferta
    {
        public int IdOfertas { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdClassificado { get; set; }
        public byte? IdSituacao { get; set; }

        public virtual Classificado IdClassificadoNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
