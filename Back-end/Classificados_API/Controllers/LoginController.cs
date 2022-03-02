using Classificados_API.Domains;
using Classificados_API.Interfaces;
using Classificados_API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
    public class LoginController : ControllerBase
    {
        private IUsuario _UsuarioRepository { get; set; }

        public LoginController(IUsuario repo)
        {
            _UsuarioRepository = repo;

        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel login)
        {
            Usuario usuarioBuscado = _UsuarioRepository.Login(login.Email,login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou Senha invalidos");
            }

            var minhasClaims = new[]
            { 
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role,usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim("role", usuarioBuscado.IdTipoUsuario.ToString())
            };
            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Classificados-chave-autenticacao"));

            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(issuer: "Classificados.webAPI", audience: "Classificados.webAPI", claims: minhasClaims, expires: DateTime.Now.AddMinutes(30), signingCredentials: Creds);

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(Token)
            });
        }
    }
}
