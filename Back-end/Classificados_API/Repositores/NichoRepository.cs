using Classificados_API.Contexts;
using Classificados_API.Domains;
using Classificados_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Classificados_API.Repositores
{
    public class NichoRepository : INicho
    {
        AakshnContext ctx = new AakshnContext();
        public List<Nicho> ListarTodos()
        {
            return ctx.Nichos.ToList();
            
        }
    }
} 
