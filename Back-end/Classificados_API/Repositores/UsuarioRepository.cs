using Classificados_API.Contexts;
using Classificados_API.Domains;
using Classificados_API.Interfaces;
using Classificados_API.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Classificados_API.Repositores
{
    public class UsuarioRepository : IUsuario
    {
        AakshnContext ctx = new AakshnContext();
        public void Atualizar(int Id, Usuario UsuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscaPorId(Id);
            if (usuarioBuscado!= null)
            {
                usuarioBuscado.Nome = UsuarioAtualizado.Nome;
                usuarioBuscado.Sobrenome = UsuarioAtualizado.Sobrenome;
                usuarioBuscado.Ddd = UsuarioAtualizado.Ddd;
                usuarioBuscado.Telefone = UsuarioAtualizado.Telefone;

                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public Usuario BuscaPorId(int Id)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == Id);
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);
            NovoUsuario.Senha = Criptografia.GerarHash(NovoUsuario.Senha);
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string Email, string Senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == Email);

            if (usuario != null)
            {
                bool confere = Criptografia.CompararHash(Senha, usuario.Senha);
                if (confere)
                    return usuario;
            }

            return ctx.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
            //return null;
        }
    }
}
