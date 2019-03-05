using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.ViewModels
{
    public class UserViewModel
    {
        [RegularExpression(@"^[a-z0-9]{4,20}$", ErrorMessage = "O nome do usuário é obrigatório, deve conter apenas letras e números, e possuir entre 4 e 20 caracteres.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha é obrigatória e deve conter entre 6 e 20 caracteres.")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="As senhas digitadas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}