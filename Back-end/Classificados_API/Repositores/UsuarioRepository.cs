using Classificados_API.Contexts;
using Classificados_API.Domains;
using Classificados_API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Classificados_API.Repositores
{
    public class UsuarioRepository : IUsuario
    {
        AakshnContext ctx = new AakshnContext();
        public void Atualizar(int Id, Usuario ConsultumAtualizado)
        {
            throw new System.NotImplementedException();
        }

        public Usuario BuscaPorId(int Id)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == Id);
        }

        public void Cadastrar(Usuario NovoConsultum)
        {
            throw new System.NotImplementedException();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string Email, string Senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
        }
    }
}
