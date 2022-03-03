using Classificados_API.Contexts;
using Classificados_API.Domains;
using Classificados_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Classificados_API.Repositores
{
    public class ClassificadoRepository : IClassificado
    {
        AakshnContext ctx = new AakshnContext();
        public void Atualizar(int Id, Classificado ClassificadosAtualizado)
        {
            Classificado ClassificadoBuscado = BuscaPorId(Id);
            if (ClassificadoBuscado != null)
            {
                ClassificadoBuscado.IdSituacao = ClassificadosAtualizado.IdSituacao;
                ClassificadoBuscado.Titulo = ClassificadosAtualizado.Titulo;
                ClassificadoBuscado.Descricao = ClassificadosAtualizado.Descricao;
                ClassificadoBuscado.DataExpiracao = ClassificadosAtualizado.DataExpiracao;

                ctx.Classificados.Update(ClassificadoBuscado);
                ctx.SaveChanges();

            }
        }

        public Classificado BuscaPorId(int Id)
        {
            return ctx.Classificados.Include(x => x.IdSituacaoNavigation)
                .Select(x => new Classificado()
                {
                    IdClassificado = x.IdClassificado,
                    IdSituacao = x.IdSituacao,
                    IdUsuario = x.IdUsuario,
                    Titulo = x.Titulo,
                    Descricao = x.Descricao,
                    DataCricao = x.DataCricao,
                    DataExpiracao = x.DataExpiracao,
                    Acessos = x.Acessos,
                    IdSituacaoNavigation = new Situacao()
                    {
                        Situacao1 = x.IdSituacaoNavigation.Situacao1

                    }
                }).FirstOrDefault(c => c.IdClassificado == Id);
        }

        public void Cadastrar(Classificado NovoClassificados)
        {
            ctx.Classificados.Add(NovoClassificados);
            ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            ctx.Classificados.Remove(BuscaPorId(Id));
            ctx.SaveChanges();
        }

        public List<Classificado> ListarMinhas(int IdUsuario)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == IdUsuario);

            if (UsuarioBuscado != null)
            {
                return ctx.Classificados.Where(c => c.IdUsuario == UsuarioBuscado.IdUsuario).Include(x => x.IdUsuarioNavigation)
                    .Select(x => new Classificado()
                    {
                        IdClassificado= x.IdClassificado,
                        IdUsuario= x.IdUsuario,
                        Titulo = x.Titulo,
                        Descricao = x.Descricao,
                        DataCricao= x.DataCricao,
                        DataExpiracao= x.DataExpiracao,
                        Acessos= x.Acessos,
                        IdSituacaoNavigation = new Situacao()
                        {
                            Situacao1 = x.IdSituacaoNavigation.Situacao1

                        }
                    })
                    .ToList();
            }
            return null;
        }

        public List<Classificado> ListarTodos()
        {
            return ctx.Classificados.Include(x => x.IdSituacaoNavigation)
                .Select(x => new Classificado()
                {
                    IdClassificado = x.IdClassificado,
                    IdSituacao = x.IdSituacao,
                    IdUsuario = x.IdUsuario,
                    Titulo = x.Titulo,
                    Descricao = x.Descricao,
                    DataCricao = x.DataCricao,
                    DataExpiracao = x.DataExpiracao,
                    Acessos = x.Acessos,
                    IdSituacaoNavigation = new Situacao()
                    {
                        Situacao1 = x.IdSituacaoNavigation.Situacao1

                    }
                }).ToList();

        }

        public void Situacao(int IdClassificados, byte idSituacao)
        {
            Classificado ClassificadoBuscado = ctx.Classificados.FirstOrDefault(c => c.IdClassificado == IdClassificados);
            
            ClassificadoBuscado.IdSituacao = idSituacao;

            ctx.Classificados.Update(ClassificadoBuscado);
            ctx.SaveChanges();


        }
    }
}
