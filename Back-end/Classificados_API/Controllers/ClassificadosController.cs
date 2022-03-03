using Classificados_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classificados_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificadosController : ControllerBase
    {
        private IClassificado _ClassificadoRepository { get; set; }

        public ClassificadosController(IClassificado repo)
        {
            _ClassificadoRepository = repo;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_ClassificadoRepository.ListarTodos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            if (_ClassificadoRepository.BuscaPorId(id) == null)
            {
                return BadRequest(new
                {
                    mensagem = "Id nao existente!"
                });
            }
            return Ok(_ClassificadoRepository.BuscaPorId(id));
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            if (_ClassificadoRepository.BuscaPorId(id) == null)
            {
                return BadRequest(new { menssagem = "Esse id nao existe" });
            }
            _ClassificadoRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
