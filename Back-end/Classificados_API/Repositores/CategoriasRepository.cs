using Classificados_API.Contexts;
using Classificados_API.Domains;
using Classificados_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Classificados_API.Repositores
{
    public class CategoriasRepository : ICategorias
    {
        AakshnContext ctx = new AakshnContext();

        public List<Categoria> ListarTodos()
        {
            return ctx.Categorias
                .Include(x => x.IdNichoNavigation)
                .Select(x => new Categoria()
                {
                    IdCategoria = x.IdCategoria,
                    Categoria1 = x.Categoria1,
                    IdNichoNavigation = new Nicho()
                    {
                        IdNicho = x.IdNichoNavigation.IdNicho,
                        Nicho1 = x.IdNichoNavigation.Nicho1
                    }
                }).ToList();
        }
    }
}
