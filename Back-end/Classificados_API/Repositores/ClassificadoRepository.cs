using Classificados_API.Contexts;
using Classificados_API.Domains;
using Classificados_API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Classificados_API.Repositores
{
    public class ClassificadoRepository : IClassificado
    {
        AakshnContext ctx = new AakshnContext();
        public void Atualizar(int Id, Classificado ConsultumAtualizado)
        {
            throw new System.NotImplementedException();
        }

        public Classificado BuscaPorId(int Id)
        {
            return ctx.Classificados.FirstOrDefault(c => c.IdClassificado == Id);
        }

        public void Cadastrar(Classificado NovoConsultum)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(int Id)
        {
            ctx.Classificados.Remove(BuscaPorId(Id));
            ctx.SaveChanges();
        }

        public List<Classificado> ListarMinhas(int IdUsuario)
        {
            throw new System.NotImplementedException();
        }

        public List<Classificado> ListarTodos()
        {
            return ctx.Classificados.ToList();
        }

        public void Situacao(int IdSituacao, string Status)
        {
            throw new System.NotImplementedException();
        }
    }
}
