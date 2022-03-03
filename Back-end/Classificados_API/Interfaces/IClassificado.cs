using Classificados_API.Domains;
using System.Collections.Generic;

namespace Classificados_API.Interfaces
{
    public interface IClassificado
    {
        void Cadastrar(Classificado NovoClassificados);

        void Deletar(int Id);

        List<Classificado> ListarTodos();

        Classificado BuscaPorId(int Id);

        void Atualizar(int Id, Classificado ClassificadosAtualizado);

        List<Classificado> ListarMinhas(int IdUsuario);

        void Situacao(int IdClassificados, byte idSituacao);
    }
}
