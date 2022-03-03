using Classificados_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classificados_API.Interfaces
{
    interface ISituacao
    {
        List<Situacao> ListarTodos();
    }
}
