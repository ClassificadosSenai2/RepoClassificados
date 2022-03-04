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

        [HttpPost("imagem/bd")]
        public IActionResult PostBD(IFormFile arquivo)
        {
            try
            {
                if (arquivo.Length > 10000) //10MB
                {
                    return BadRequest(new { mensagem = "O tamanho maximo da imagem foi atingida" });
                }

                string extensao = arquivo.FileName.Split('.').Last();

                if (extensao != "png")
                {
                    return BadRequest(new { mensagem = "Apenas arquivos .png são permitidos" });
                }

                short idUsuario = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.SalvarPerfilBD(arquivo, idUsuario);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("imagem/bd")]
        public IActionResult getBd()
        {
            try
            {
                short idUsuario = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                string base64 = _UsuarioRepository.ConsultarPerfilBD(idUsuario);
                return Ok(base64);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
