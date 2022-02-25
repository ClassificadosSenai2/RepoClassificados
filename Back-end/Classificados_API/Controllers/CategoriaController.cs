using Classificados_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Classificados_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategorias _CategoriaRepository { get; set; }

        public CategoriaController(ICategorias repo)
        {
            _CategoriaRepository = repo;

        }

        [HttpGet]

        public IActionResult ListarTodos()
        {
            try
            {
                //List<TipoClassificado> LIstarTodos = _TipoClassificadosRepository.ListarTodos();
                return Ok(_CategoriaRepository.ListarTodos());

            }
            catch (Exception erro)
            {
                return BadRequest(erro);

            }
        }
    }
}
