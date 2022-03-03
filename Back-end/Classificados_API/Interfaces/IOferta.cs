using Classificados_API.Domains;
using System.Collections.Generic;

namespace Classificados_API.Interfaces
{
    public interface IOferta
    {
        List<Oferta> ListarMinhas(int IdClassificado);
        void Cadastrar(Oferta novaOferta);

        void Situacao(int IdSituacao, string Status);
    }
}
