using Classificados_API.Contexts;
using Classificados_API.Domains;
using Classificados_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Classificados_API.Repositores
{
    public class OfertaRepository : IOferta
    {
        AakshnContext ctx = new AakshnContext();
        public void Cadastrar(Oferta novaOferta)
        {
            ctx.Ofertas.Add(novaOferta);
            ctx.SaveChanges();
        }

        public List<Oferta> ListarMinhas(int IdClassificado)
        {
            Oferta OfertaBuscada = ctx.Ofertas.FirstOrDefault(x => x.IdUsuario == IdClassificado);

            if (OfertaBuscada != null)
            {
                return ctx.Ofertas.Where(c => c.IdUsuario == OfertaBuscada.IdUsuario).Include(x => x.IdUsuarioNavigation).Include(x => x.IdSituacaoNavigation).Include(x => x.IdClassificadoNavigation)
                    .Select(x => new Oferta()
                    {
                        IdOfertas = x.IdOfertas,
                        IdUsuario = x.IdUsuario,
                        IdClassificado = x.IdClassificado,
                        IdSituacao = x.IdSituacao,
                        Descricao = x.Descricao,

                        IdUsuarioNavigation = new Usuario()
                        {
                            Nome = x.IdUsuarioNavigation.Nome,
                            Sobrenome = x.IdUsuarioNavigation.Sobrenome,
                            Email = x.IdUsuarioNavigation.Email
                        },

                        IdClassificadoNavigation = new Classificado() 
                        { 
                            Titulo = x.IdClassificadoNavigation.Titulo                        
                        },

                        IdSituacaoNavigation = new Situacao()
                        {
                            Situacao1 = x.IdSituacaoNavigation.Situacao1
                        }


                    })
                    .ToList();
            }
            return null; ;
        }

        public void Situacao(int IdOferta, byte idSituacao)
        {
            Oferta OfertaBuscado = ctx.Ofertas.FirstOrDefault(c => c.IdOfertas == IdOferta);

            OfertaBuscado.IdSituacao = idSituacao;

            ctx.Ofertas.Update(OfertaBuscado);
            ctx.SaveChanges();
        }
    }
}
