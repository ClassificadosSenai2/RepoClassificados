using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Classificados_API.ViewModels
{
    /// <summary>
    /// Classe Reponsavel pelo modelo de login 
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Infrome o meial do usuario!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha o usuario")]

        public string Senha { get; set; }
    } 
}
