using Classificados_API.Contexts;
using Classificados_API.Domains;
using Classificados_API.Interfaces;
using System.Collections.Generic;

namespace Classificados_API.Repositores
{
    public class CategoriasRepository : ICategorias
    {
        AakshnContext ctx = new AakshnContext();

        public List<Categoria> ListarTodos()
        {
            return ctx.Categorias.ToList();
        }
    }
}
