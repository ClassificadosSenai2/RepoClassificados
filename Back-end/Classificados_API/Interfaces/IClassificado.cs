using Classificados_API.Domains;
using System.Collections.Generic;

namespace Classificados_API.Interfaces
{
    public interface IClassificado
    {
        void Cadastrar(Classificado NovoConsultum);

        void Deletar(int Id);

        List<Classificado> ListarTodos();

        Classificado BuscaPorId(int Id);

        void Atualizar(int Id, Classificado ConsultumAtualizado);

        List<Classificado> ListarMinhas(int IdUsuario);

        void Situacao(int IdSituacao, string Status);
    }
}
