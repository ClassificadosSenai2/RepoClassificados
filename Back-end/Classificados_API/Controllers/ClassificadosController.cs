using Classificados_API.Domains;
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

        [HttpPatch("{id}")]
        public IActionResult MudarSituacao(int id, Classificado NovaSituacao)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Este id não é valido"
                    });
                }

                if(NovaSituacao.IdSituacao <= 0)
                {
                    return BadRequest(new { Mensagem = "Informe um id valido" });
                }
                _ClassificadoRepository.Situacao(id, Convert.ToByte(NovaSituacao.IdSituacao));
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(Classificado NovoClassificado)
        {
            try
            {
                _ClassificadoRepository.Cadastrar(NovoClassificado);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
