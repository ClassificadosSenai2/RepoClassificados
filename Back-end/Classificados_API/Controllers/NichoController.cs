using Classificados_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Classificados_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class NichoController : ControllerBase
    {
        private INicho _NichoRepository { get; set; }

        public NichoController(INicho repo)
        {
            _NichoRepository = repo;

        }

        [HttpGet]

        public IActionResult ListarTodos()
        {
            try
            {
                //List<TipoClassificado> LIstarTodos = _TipoClassificadosRepository.ListarTodos();
                return Ok(_NichoRepository.ListarTodos());

            }
            catch (Exception erro)
            {
                return BadRequest(erro);

            }
        }
    }
}
