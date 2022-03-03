using Classificados_API.Domains;
using System.Collections.Generic;

namespace Classificados_API.Interfaces
{
    public interface IUsuario
    {
        List<Usuario> ListarTodos();
        void Cadastrar(Usuario NovoUsuario);
        Usuario BuscaPorId(int Id);
        void Atualizar(int Id, Usuario UsuarioAtualizado);
        Usuario Login(string Email, string Senha);

    }
}
