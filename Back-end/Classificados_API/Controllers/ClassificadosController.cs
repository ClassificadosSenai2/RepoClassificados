using Classificados_API.Domains;
using Classificados_API.Interfaces;
using Classificados_API.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        public IActionResult Cadastrar([FromForm] Classificado NovoClassificado, IFormFile arquivo)
        {
            try
            {

                string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado");
                }

                if (uploadResultado == "Extensão não permitida")
                {
                    return BadRequest("Extensão de arquivo não permitida");
                }

                //NovoClassificado.Imagem = uploadResultado;

                NovoClassificado.DataCricao = DateTime.Now;

                _ClassificadoRepository.Cadastrar(NovoClassificado);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("ListarMinhas")]
        public IActionResult LIstarMinhas()
        {
            try
            {
                short id = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                //short idTipo = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);
                List<Classificado> listaClassificado = _ClassificadoRepository.ListarMinhas(id);

                if (listaClassificado.Count == 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Não há nenhuma Classificação"
                    });
                }
                return Ok(listaClassificado);

            }
            catch (Exception erro)
            {

                return BadRequest(new
                {
                    mensagem = "Nao foi possivel ver seus Classificados",
                    erro
                });
            }
        }
    }
}
