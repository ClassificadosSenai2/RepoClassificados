using System;
using System.Collections.Generic;

#nullable disable

namespace Classificados_API.Domains
{
    public partial class ImagemBanco
    {
        public int IdImg { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdClassificado { get; set; }
        public byte[] Binario { get; set; }
        public string MimeType { get; set; }
        public string NomeArquivo { get; set; }

        public virtual Classificado IdClassificadoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
