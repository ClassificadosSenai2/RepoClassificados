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
    public class UsuariosController : ControllerBase
    {
        private IUsuario _UsuarioRepository { get; set; }

        public UsuariosController(IUsuario repo)
        {
            _UsuarioRepository = repo;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_UsuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            if (_UsuarioRepository.BuscaPorId(id) == null)
            {
                return BadRequest(new
                {
                    mensagem = "Id nao existente!"
                });
            }
            return Ok(_UsuarioRepository.BuscaPorId(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario NovoUsuario)
        {
            try
            {
                _UsuarioRepository.Cadastrar(NovoUsuario);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario UsuarioAtualizado)
        {
            try
            {
                _UsuarioRepository.Atualizar(id, UsuarioAtualizado);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
