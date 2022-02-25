using Classificados_API.Domains;
using System.Collections.Generic;

namespace Classificados_API.Interfaces
{
    public interface ICategorias
    {
        List<Categoria> ListarTodos();
    }
}
