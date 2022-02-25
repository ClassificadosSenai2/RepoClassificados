using Classificados_API.Domains;
using Classificados_API.Interfaces;
using Classificados_API.Repositores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Classificados_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoClassificadoController : ControllerBase
    {
        private ITipoClassificados _TipoClassificadosRepository { get; set; }

        public TipoClassificadoController(ITipoClassificados repo)
        {
            _TipoClassificadosRepository = repo;
            
        }

        [HttpGet]

        public IActionResult ListarTodos()
        {
            try
            {
                //List<TipoClassificado> LIstarTodos = _TipoClassificadosRepository.ListarTodos();
                return Ok(_TipoClassificadosRepository.ListarTodos());

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                
            }
        }


    }
}
