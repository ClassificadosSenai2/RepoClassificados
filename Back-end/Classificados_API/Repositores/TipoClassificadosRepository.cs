using Classificados_API.Contexts;
using Classificados_API.Domains;
using Classificados_API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Classificados_API.Repositores
{
    public class TipoClassificadosRepository : ITipoClassificados
    {
        AakshnContext ctx = new AakshnContext();

        public List<TipoClassificado> ListarTodos()
        {
            return ctx.TipoClassificados.ToList();
        }
    }
}
