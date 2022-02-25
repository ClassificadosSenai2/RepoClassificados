using Classificados_API.Domains;
using System.Collections.Generic;

namespace Classificados_API.Interfaces
{
    public interface IUsuario
    {
        List<Usuario> ListarTodos();
        void Cadastrar(Usuario NovoConsultum);
        Usuario BuscaPorId(int Id);
        void Atualizar(int Id, Usuario ConsultumAtualizado);
        Usuario Login(string Email, string Senha);

    }
}
