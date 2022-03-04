using Classificados_API.Domains;
using Classificados_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Classificados_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OfertasController : ControllerBase
    {
        private IOferta _OfertaRepository { get; set; }
        //private IClassificado _ClassificadoRepository { get; set; }

        public OfertasController(IOferta repo)
        {

            _OfertaRepository = repo;
        }
        

        [HttpPatch("{id}")]
        public IActionResult MudarSituacao(int id, Oferta NovaOferta)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Este id não é valido"
                    });
                }

                if (NovaOferta.IdSituacao <= 0)
                {
                    return BadRequest(new { Mensagem = "Informe um id valido" });
                }
                _OfertaRepository.Situacao(id, Convert.ToByte(NovaOferta.IdSituacao));
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(Oferta NovaOferta)
        {
            try
            {
                _OfertaRepository.Cadastrar(NovaOferta);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("ListarMinhas/{id}")]
        public IActionResult LIstarMinhas(int id)
        {
            try
            {
               // Classificado classificadoBuscado = _ClassificadoRepository.BuscaPorId(id);
                //if (classificadoBuscado != null)
                
                    List<Oferta> listaOferta = _OfertaRepository.ListarMinhas(id);

                    if (listaOferta.Count == 0)
                    {
                        return BadRequest(new
                        {
                            Mensagem = "Não há nenhuma Classificação"
                        });
                    }
                    return Ok(listaOferta);
                
                return null;

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
