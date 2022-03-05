using Classificados_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Classificados_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilsController : ControllerBase
    {

        private IUsuario _UsuarioRepository { get; set; }

        public PerfilsController(IUsuario repo)
        {
            _UsuarioRepository = repo;
        }

        
    }
}
